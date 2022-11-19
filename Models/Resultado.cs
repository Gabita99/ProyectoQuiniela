using System;
using System.Collections.Generic;

namespace ProyectoQuiniela.Models
{
    public partial class Resultado
    {
        public int IdResultado { get; set; }
        public int IdPartido { get; set; }
        public int GolA { get; set; }
        public int GolB { get; set; }
        public int IdTipo { get; set; }

        public virtual Partido IdPartidoNavigation { get; set; } = null!;
        public virtual TipoResultado IdTipoNavigation { get; set; } = null!;
    }
}
