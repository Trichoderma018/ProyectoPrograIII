using Microsoft.AspNetCore.Mvc;
using AppFinanzas.Models;
using AppFinanzas.Recursos;
using AppFinanzas.Servicios.Contrato;

using System.Security.Claims;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore;

namespace AppFinanzas.Controllers
{
    public class InicioController : Controller
    {
        private readonly IUsuarioService _usuarioServicio;
        public InicioController(IUsuarioService usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }
        public async IActionResult Registrarse()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Registrarse(Usuario modelo)
        {
            modelo.Contrasena = Utilidades.EncriptarClave(modelo.Contrasena);

            Usuario usuario_creado = await usuario_creado.SaveUsuario(modelo);
            return View();
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }
        [HttpPost]
        public IActionResult IniciarSesion()
        {
            return View();
        }
    }
}
