using System;
using System.Collections.Generic;

namespace ProyectoQuiniela.Models
{
    public partial class Premio
    {
        public int IdPremios { get; set; }
        public string Puesto { get; set; } = null!;
        public int IdLiga { get; set; }
        public int? IdTipoPremio { get; set; }

        public virtual Liga IdLigaNavigation { get; set; } = null!;
        public virtual TipoPremio IdTipoPremioNavigation { get; set; }
    }
}
