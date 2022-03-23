using System;
using System.Collections.Generic;

namespace PetService.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Mascota = new HashSet<Mascotas>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string ApellidoP { get; set; } = null!;
        public string? ApellidoM { get; set; }
        public string Correo { get; set; } = null!;
        public string Contra { get; set; } = null!;
        public DateTime? Edad { get; set; }

        public virtual ICollection<Mascotas> Mascota { get; set; }
    }
}
