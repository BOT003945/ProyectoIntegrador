using System;
using System.Collections.Generic;

namespace PetServiceBlazor.Data.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Mascota = new HashSet<Mascota>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string ApellidoP { get; set; } = null!;
        public string? ApellidoM { get; set; }
        public int IdRol { get; set; }

        public string? GetName()
        {
            return $"{Nombre} {ApellidoP} {ApellidoM}";
        }

        public virtual Rol IdRolNavigation { get; set; } = null!;
        public virtual ICollection<Mascota> Mascota { get; set; }
    }
}
