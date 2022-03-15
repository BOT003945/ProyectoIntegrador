using System;
using System.Collections.Generic;

namespace PetServiceBlazor.Data.Models
{
    /// <summary>
    /// Tabla Servicio, donde se almacenan los diferentes tipos de servicios.
    /// </summary>
    public partial class Servicio
    {
        public Servicio()
        {
            Cita = new HashSet<Cita>();
        }

        /// <summary>
        /// Campo IdServicio, llave primaria en la tabla Servicio.
        /// </summary>
        public int IdServicio { get; set; }
        public string NombreServicio { get; set; } = null!;

        public virtual ICollection<Cita> Cita { get; set; }
    }
}
