using System;
using System.Collections.Generic;

namespace ProyectoQuiniela.Models
{
    public partial class TipoPremio
    {
        public TipoPremio()
        {
            Premios = new HashSet<Premio>();
        }

        public int IdTipoPremio { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Premio> Premios { get; set; }
    }
}
