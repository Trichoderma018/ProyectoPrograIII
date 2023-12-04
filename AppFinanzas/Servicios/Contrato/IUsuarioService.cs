using Microsoft.EntityFrameworkCore;
using AppFinanzas.Models;

namespace AppFinanzas.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario>GetUsuario(string Correo, string Contrasena);
        Task<Usuario> SaveUsuario(Usuario modelo);
    }
}
