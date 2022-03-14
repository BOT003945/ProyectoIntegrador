using System;
using System.Collections.Generic;

namespace PetServiceBlazor.Data.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Cita = new HashSet<Cita>();
            Mascota = new HashSet<Mascota>();
            Venta = new HashSet<Venta>();
        }

        public int IdUsuario { get; set; }
        public string Nombres { get; set; } = null!;
        public string ApellidoP { get; set; } = null!;
        public string ApellidoM { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
        public string? Sexo { get; set; }
        public string Correo { get; set; } = null!;
        public string Contra { get; set; } = null!;
        public string? VerificacionEmail { get; set; }
        public string? FotoPerfil { get; set; }
        public string? RememberToken { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public int IdRol { get; set; }

        public string? GetName()
        {
            return $"{Nombres} {ApellidoP} {ApellidoM}";
        }

        public virtual Rol IdRolNavigation { get; set; } = null!;
        public virtual ICollection<Cita> Cita { get; set; }
        public virtual ICollection<Mascota> Mascota { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
