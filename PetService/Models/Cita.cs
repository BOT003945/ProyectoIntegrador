using System;
using System.Collections.Generic;

namespace PetService.Models
{
    public partial class Cita
    {
        public int IdCita { get; set; }
        public int? IdServicio { get; set; }
        public int IdUsuario { get; set; }
        public int IdMascota { get; set; }
        public DateTime Fecha { get; set; }
        public string? Descripcion { get; set; }

        public virtual Mascota IdMascotaNavigation { get; set; } = null!;
        public virtual Servicio? IdServicioNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
