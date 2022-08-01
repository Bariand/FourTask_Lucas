using FourTask_Lucas.Areas.Identity.Data;
using FourTask_Lucas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FourTask_Lucas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FourTask_LucasContext _context;
        private readonly UserManager<Usuario> _userManager;

        public HomeController(ILogger<HomeController> logger, 
            FourTask_LucasContext context, 
            UserManager<Usuario> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            Usuario usuarioLogado = _context.Usuarios.Find(_userManager.GetUserId(User));
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}