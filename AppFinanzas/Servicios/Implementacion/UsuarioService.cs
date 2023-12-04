using Microsoft.EntityFrameworkCore;
using AppFinanzas.Models;
using AppFinanzas.Servicios.Contrato;

namespace AppFinanzas.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly FinanzasContext _DbContext;

        public UsuarioService(FinanzasContext DbContext)
        {
            _DbContext = DbContext;
        }
        public async Task<Usuario> GetUsuario(string Correo, string Contrasena)
        {
            Usuario usuario_encontrado = await _DbContext.Usuarios.Where(u => u.Correo == Correo && u.Contrasena == Contrasena)
                .FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _DbContext.Usuarios.Add(modelo);
            await _DbContext.SaveChangesAsync();
            return modelo;
        }
    }
}
