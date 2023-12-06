using AppFinanzas.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace AppFinanzas.Controllers
{
    [Authorize]
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

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("IniciarSesion", "Inicio");
        }

        //[Authorize(Roles = "Administrador")]
        public IActionResult Categoriums()
        {
            return View();
        }
        //[Authorize(Roles = "Administrador")]
        public IActionResult ConfiguracionUsuarios()
        {
            return View();
        }
        //[Authorize(Roles = "Administrador")]
        public IActionResult Roles()
        {
            return View();
        }
        //[Authorize(Roles = "Administrador")]
        public IActionResult RolesPorUsuarios()
        {
            return View();
        }

        public IActionResult Tansacciones()
        {
            return View();
        }

        public IActionResult Usuarios()
        {
            return View();
        }
    }
}