using System;
using System.Collections.Generic;

namespace ProyectoQuiniela.Models
{
    public partial class Grupo
    {
        public Grupo()
        {
            DetalleEquipos = new HashSet<DetalleEquipo>();
        }

        public int IdGrupo { get; set; }
        public string Grupo1 { get; set; } = null!;

        public virtual ICollection<DetalleEquipo> DetalleEquipos { get; set; }
    }
}
