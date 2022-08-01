using FourTask_Lucas.Areas.Identity.Data;
using FourTask_Lucas.Models;
using FourTask_Lucas.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FourTask_Lucas.Controllers
{
    public class TarefaController : Controller
    {
        private ITarefaRepository _tarefaRepository;
        private UserManager<Usuario> _userManager;

        private Areas.Identity.Data.FourTask_LucasContext _context;
        public TarefaController(Areas.Identity.Data.FourTask_LucasContext context, ITarefaRepository tarefaRepository, UserManager<Usuario> userManager)
        {
            _context = context;
            _tarefaRepository = tarefaRepository;
            _userManager = userManager;
        }

        [HttpGet, Authorize]
        public IActionResult Index(int id)
        {
            Tarefa tarefa = _tarefaRepository.BuscarPorId(id);
            
            return View(tarefa);
        }

        [HttpGet, Authorize]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost, Authorize]
        public IActionResult Cadastrar(Tarefa tarefa)
        {
            Usuario user = _context.Usuarios.Where(u => u.Id == _userManager.GetUserId(User)).FirstOrDefault();
            tarefa.EquipeId = (int)user.EquipeId;

            if (ModelState.IsValid)
            {
                
                _tarefaRepository.Adicionar(tarefa);
                _tarefaRepository.Salvar();

                TempData["TarefaCadastrada"] = "Tarefa cadastrada com sucesso!";

                return RedirectToAction("Index", "Equipe");
            }

            return View();
        }

        [HttpGet, Authorize]
        public IActionResult Editar(int id)
        {
            Tarefa tarefa = _tarefaRepository.BuscarPorId(id);
            return View(tarefa);
        }

        [HttpPost, Authorize]
        public IActionResult Editar(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                _tarefaRepository.Atualizar(tarefa);
                _tarefaRepository.Salvar();

                TempData["TarefaEditada"] = "Tarefa editada com sucesso!";

                return RedirectToAction("Index", "Equipe");
            }

            return View(tarefa);
        }

        public IActionResult AceitarTarefa(int id)
        {
            Usuario user = _context.Usuarios.Where(u => u.Id == _userManager.GetUserId(User)).FirstOrDefault();
            Tarefa tarefa =  _tarefaRepository.BuscarPorId(id);

            if (tarefa.UsuarioId == user.Id)
            {
                TempData["TarefaJaInscrito"] = "Você já está inscrito nesta tarefa!";

                return RedirectToAction("Index", "Equipe");
            }

            tarefa.UsuarioId = user.Id;
            _tarefaRepository.Atualizar(tarefa);
            _tarefaRepository.Salvar();

            TempData["TarefaAceita"] = "Você aceitou a tarefa!";

            return RedirectToAction("Index", "Equipe");
        }

        [HttpPost]
        public IActionResult Excluir(int id)
        {
            _tarefaRepository.Remover(id);
            _tarefaRepository.Salvar();

            TempData["TarefaExcluida"] = "Você excluiu a tarefa com sucesso!";

            return RedirectToAction("Index", "Equipe");
        }
    }
}
