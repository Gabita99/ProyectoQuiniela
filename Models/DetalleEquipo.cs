using System;
using System.Collections.Generic;

namespace ProyectoQuiniela.Models
{
    public partial class DetalleEquipo
    {
        public int IdDetalle { get; set; }
        public int IdEquipo { get; set; }
        public int IdGrupo { get; set; }
        public int IdLiga { get; set; }

        public virtual Equipo IdEquipoNavigation { get; set; } = null!;
        public virtual Grupo IdGrupoNavigation { get; set; } = null!;
        public virtual Liga IdLigaNavigation { get; set; } = null!;
    }
}
