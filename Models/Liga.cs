using System;
using System.Collections.Generic;

namespace ProyectoQuiniela.Models
{
    public partial class Liga
    {
        public Liga()
        {
            DetalleEquipos = new HashSet<DetalleEquipo>();
            Invitaciones = new HashSet<Invitacione>();
            Premios = new HashSet<Premio>();
        }

        public int IdLiga { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }

        public virtual ICollection<DetalleEquipo> DetalleEquipos { get; set; }
        public virtual ICollection<Invitacione> Invitaciones { get; set; }
        public virtual ICollection<Premio> Premios { get; set; }
    }
}
