using System;
using System.Collections.Generic;

namespace ProyectoQuiniela.Models
{
    public partial class Partido
    {
        public Partido()
        {
            QuinielaPredicciones = new HashSet<QuinielaPrediccione>();
            Resultados = new HashSet<Resultado>();
        }

        public int IdPartido { get; set; }
        public int EquipoA { get; set; }
        public int EquipoB { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Equipo EquipoANavigation { get; set; } = null!;
        public virtual Equipo EquipoBNavigation { get; set; } = null!;
        public virtual ICollection<QuinielaPrediccione> QuinielaPredicciones { get; set; }
        public virtual ICollection<Resultado> Resultados { get; set; }
    }
}
