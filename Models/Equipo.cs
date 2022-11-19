using System;
using System.Collections.Generic;

namespace ProyectoQuiniela.Models
{
    public partial class Equipo
    {
        public Equipo()
        {
            DetalleEquipos = new HashSet<DetalleEquipo>();
            PartidoEquipoANavigations = new HashSet<Partido>();
            PartidoEquipoBNavigations = new HashSet<Partido>();
        }

        public int IdEquipo { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<DetalleEquipo> DetalleEquipos { get; set; }
        public virtual ICollection<Partido> PartidoEquipoANavigations { get; set; }
        public virtual ICollection<Partido> PartidoEquipoBNavigations { get; set; }
    }
}
