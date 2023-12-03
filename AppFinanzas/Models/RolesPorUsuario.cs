using System;
using System.Collections.Generic;

namespace AppFinanzas.Models
{
    public partial class RolesPorUsuario
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
