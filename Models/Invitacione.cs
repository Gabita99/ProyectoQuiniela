using System;
using System.Collections.Generic;

namespace ProyectoQuiniela.Models
{
    public partial class Invitacione
    {
        public int IdInvitacion { get; set; }
        public int IdUsuario { get; set; }
        public int IdLiga { get; set; }

        public virtual Liga IdLigaNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
