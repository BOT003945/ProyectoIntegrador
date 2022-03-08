using System;
using System.Collections.Generic;
using PetServiceBlazor.Data.Models;


namespace PetServiceBlazor.Data.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Propietarios = new HashSet<Propietario>();
        }

        public int IdUsuario { get; set; }
        public string? Correo { get; set; }
        public string? FotoUsuario { get; set; }
        public string Usuario1 { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }

        public virtual ICollection<Propietario> Propietarios { get; set; }
    }
}
