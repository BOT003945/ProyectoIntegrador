using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [EmailAddress]
        public string Correo { get; set; } = null!;
        public string Contra { get; set; } = null!;
        public DateTime? Edad { get; set; }

        public string? GetName()
        {
            return $"{Nombre} {ApellidoP} {ApellidoM}";
        }

        public virtual ICollection<Mascota> Mascota { get; set; }

    }
}
