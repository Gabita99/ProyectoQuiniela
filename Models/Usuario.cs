using System;
using System.Collections.Generic;

namespace ProyectoQuiniela.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Invitaciones = new HashSet<Invitacione>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Contra { get; set; } = null!;
        public string Estatus { get; set; } = null!;
        public int IdRol { get; set; }

        public virtual Role IdRolNavigation { get; set; } = null!;
        public virtual ICollection<Invitacione> Invitaciones { get; set; }
    }
}
