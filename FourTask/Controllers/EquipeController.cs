using FourTask_Lucas.Repositories;
using Microsoft.AspNetCore.Mvc;
using FourTask_Lucas.Models;
using Microsoft.AspNetCore.Authorization;
using FourTask_Lucas.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FourTask_Lucas.ViewModel;

namespace FourTask_Lucas.Controllers
{
    public class EquipeController : Controller
    {
        private IUsuarioRepository _usuarioRepository;
        private ITarefaRepository _tarefaRepository;
        private IEquipeRepository _equipeRepository;
        private UserManager<Usuario> _userManager;

        private Areas.Identity.Data.FourTask_LucasContext _context;

        public EquipeController(Areas.Identity.Data.FourTask_LucasContext context, IUsuarioRepository usuarioRepository, ITarefaRepository tarefaRepository, IEquipeRepository equipeRepository, UserManager<Usuario> userManager)
        {
            _context = context;
            _usuarioRepository = usuarioRepository;
            _tarefaRepository = tarefaRepository;
            _equipeRepository = equipeRepository;
            _userManager = userManager;
        }

        [HttpGet, Authorize]
        public IActionResult Index()
        {
            Usuario user = _context.Usuarios.Include(u => u.Equipe).Where(u => u.Id == _userManager.GetUserId(User)).FirstOrDefault(); 

            if (user.Id == null)
            {
                return View(Listagem);
            }

            EquipeTarefaModel model = new EquipeTarefaModel();
            Equipe equipe = _equipeRepository.BuscarPorId(user);
            model.Equipe = equipe;
            model.Tarefas = _tarefaRepository.Listar();

            return View(model);
        }


        [HttpPost, Authorize]
        public IActionResult Index(Usuario usuario, Equipe equipe)
        {
            usuario.EquipeId = equipe.EquipeId;
            _usuarioRepository.Salvar();
            
            return RedirectToAction("Index");
        }

        [HttpGet, Authorize]
        public IActionResult Listagem()
        {
            var equipes = _equipeRepository.Listar();      
            return View(equipes);
        }

        [HttpGet, Authorize]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost, Authorize]
        public IActionResult Cadastrar(Equipe equipe)
        {
            if (ModelState.IsValid)
            {
                _equipeRepository.Cadastrar(equipe);
                _equipeRepository.Salvar();
                TempData["EquipeCadastrada"] = "Equipe cadastrada com sucesso!";
                return RedirectToAction("Listagem");
            }

            return View();
        }

        [HttpPost]
        public IActionResult EntrarEquipe(int id)
        {
            Usuario user = _context.Usuarios.Where(u => u.Id == _userManager.GetUserId(User)).FirstOrDefault();
            
            if (user.EquipeId == id)
            {
                TempData["EquipeJaInscrito"] = "Você já faz parte desta equipe!";

                return RedirectToAction("Listagem");
            }

            user.EquipeId = id;

            _usuarioRepository.Atualizar(user);
            _usuarioRepository.Salvar();

            TempData["EquipeInscrito"] = "Você agora está inscrito nesta equipe!";

            return RedirectToAction("Index");
        }
    }
}
