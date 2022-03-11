using System;
using PetServiceBlazor.Data.Models;
using System.Collections.Generic;

namespace PetServiceBlazor.Data.Models
{
    public partial class Mascota
    {
        public Mascota()
        {
            Cita = new HashSet<Cita>();
        }

        public int IdMascota { get; set; }
        public string Nombre { get; set; } = null!;
        public string Sexo { get; set; } = null!;
        public DateTime? FechaNacimiento { get; set; }
        public int? IdPropietario { get; set; }

        public virtual Propietario? IdPropietarioNavigation { get; set; }
        public virtual ICollection<Cita> Cita { get; set; }
    }
}
