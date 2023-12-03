using System;
using System.Collections.Generic;

namespace AppFinanzas.Models
{
    public partial class ConfiguracionUsuario
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int LimiteGasto { get; set; }
        public bool NotificacionActiva { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
