using System;
using System.Collections.Generic;

namespace AppFinanzas.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Tansacciones = new HashSet<Tansaccion>();
        }

        public int Id { get; set; }
        public string NombreCategoria { get; set; } = null!;

        public virtual ICollection<Tansaccion> Tansacciones { get; set; }
    }
}
