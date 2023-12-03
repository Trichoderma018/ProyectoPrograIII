using System;
using System.Collections.Generic;

namespace AppFinanzas.Models
{
    public partial class Tansaccion
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; } = null!;
        public double Monto { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Categorium Categoria { get; set; } = null!;
        public virtual Usuario Usuario { get; set; } = null!;
    }
}
