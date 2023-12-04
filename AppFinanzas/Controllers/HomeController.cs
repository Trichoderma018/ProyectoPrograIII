using AppFinanzas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace AppFinanzas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ClaimsPrincipal claimuser = HttpContext.User;
            string Nombre = "";

            if (claimuser.Identity.IsAuthenticated) {
                Nombre = claimuser.Claims.Where(c=>c.Type ==ClaimTypes.Name)
                    .Select(c=>c.Value).SingleOrDefault();
            }
            ViewData["Nombre"] = Nombre;

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