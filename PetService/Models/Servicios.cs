using System;
using System.Collections.Generic;

namespace PetService.Models
{
    /// <summary>
    /// Tabla Servicio, donde se almacenan los diferentes tipos de servicios.
    /// </summary>
    public partial class Servicios
    {
        public Servicios()
        {
            Cita = new HashSet<Citas>();
        }

        /// <summary>
        /// Campo IdServicio, llave primaria en la tabla Servicio.
        /// </summary>
        public int IdServicio { get; set; }
        public string NombreServicio { get; set; } = null!;

        public virtual ICollection<Citas> Cita { get; set; }
    }
}
