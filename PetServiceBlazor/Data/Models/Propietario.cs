using System;
using System.Collections.Generic;
using PetServiceBlazor.Data.Models;


namespace PetServiceBlazor.Data.Models
{
    public partial class Propietario
    {
        public Propietario()
        {
            Cita = new HashSet<Cita>();
            Mascota = new HashSet<Mascota>();
        }

        public int IdPropietario { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Sexo { get; set; }
        public int IdMunicipio { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; }
        public virtual Venta Venta { get; set; } = null!;
        public virtual ICollection<Cita> Cita { get; set; }
        public virtual ICollection<Mascota> Mascota { get; set; }
    }
}
