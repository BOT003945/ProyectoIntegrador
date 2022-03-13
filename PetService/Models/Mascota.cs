using System;
using System.Collections.Generic;

namespace PetService.Models
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
        public int? IdFotoMascota { get; set; }
        public int IdUsuario { get; set; }

        public virtual FotoMascota? IdFotoMascotaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<Cita> Cita { get; set; }
    }
}
