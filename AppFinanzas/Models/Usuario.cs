using System;
using System.Collections.Generic;

namespace AppFinanzas.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            ConfiguracionUsuarios = new HashSet<ConfiguracionUsuario>();
            RolesPorUsuarios = new HashSet<RolesPorUsuario>();
            Tansacciones = new HashSet<Tansaccion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Contrasena { get; set; } = null!;

        public virtual ICollection<ConfiguracionUsuario> ConfiguracionUsuarios { get; set; }
        public virtual ICollection<RolesPorUsuario> RolesPorUsuarios { get; set; }
        public virtual ICollection<Tansaccion> Tansacciones { get; set; }
    }
}
