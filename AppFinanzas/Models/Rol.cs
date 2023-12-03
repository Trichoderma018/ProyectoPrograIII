using System;
using System.Collections.Generic;

namespace AppFinanzas.Models
{
    public partial class Rol
    {
        public Rol()
        {
            RolesPorUsuarios = new HashSet<RolesPorUsuario>();
        }

        public int Id { get; set; }
        public string NombreRol { get; set; } = null!;

        public virtual ICollection<RolesPorUsuario> RolesPorUsuarios { get; set; }
    }
}
