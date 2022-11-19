using System;
using System.Collections.Generic;

namespace ProyectoQuiniela.Models
{
    public partial class TipoResultado
    {
        public TipoResultado()
        {
            Resultados = new HashSet<Resultado>();
        }

        public int IdTipo { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Resultado> Resultados { get; set; }
    }
}
