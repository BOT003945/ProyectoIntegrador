using System;
using System.Collections.Generic;

namespace PetService.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            Cita = new HashSet<Cita>();
        }

        public int IdServicio { get; set; }
        public string NombreServicio { get; set; } = null!;

        public virtual ICollection<Cita> Cita { get; set; }
    }
}
