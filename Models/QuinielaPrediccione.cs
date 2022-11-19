using System;
using System.Collections.Generic;

namespace ProyectoQuiniela.Models
{
    public partial class QuinielaPrediccione
    {
        public int IdPredicciones { get; set; }
        public int GolesA { get; set; }
        public int GolesB { get; set; }
        public int IdPartido { get; set; }
        public string EquipoA { get; set; } = null!;
        public string EquipoB { get; set; } = null!;

        public virtual Partido IdPartidoNavigation { get; set; } = null!;
    }
}
