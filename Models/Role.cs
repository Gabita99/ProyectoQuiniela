using System;
using System.Collections.Generic;

namespace ProyectoQuiniela.Models
{
    public partial class Role
    {
        public Role()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdRol { get; set; }
        public string Tipo { get; set; } = null!;
        public string Activo { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
