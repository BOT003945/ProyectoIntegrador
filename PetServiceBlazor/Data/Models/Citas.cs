using System;
using System.Collections.Generic;

namespace PetServiceBlazor.Data.Models
{
    /// <summary>
    /// Tabla citas, donde se asigna el id de la mascota y el propietario para cada servicio; por supuesto para asignación 
    /// </summary>
    public partial class Citas
    {
        /// <summary>
        /// Campo IdCita es el identificador utilizado para cada cita.
        /// </summary>
        public int IdCita { get; set; }
        /// <summary>
        /// Campo IdServicio, llave foránea que conecta con la tabla de servicios para asignarse en cada cita.
        /// </summary>
        public int IdServicio { get; set; }
        /// <summary>
        /// Campo IdUsuario, llave foránea que conecta con la tabla de usuarios que corresponde al dueño del perro.
        /// </summary>
        public int IdUsuario { get; set; }
        /// <summary>
        /// Campo IdMascota, llave foránea que conecta con la tabla de mascotas que corresponde al perro de la persona.
        /// </summary>
        public int IdMascota { get; set; }
        /// <summary>
        /// Campo Fecha, atributo de tiempo para designar el día de la cita.
        /// </summary>
        public DateTime Fecha { get; set; }
        /// <summary>
        /// Campo HoraInicial, atributo para designar la hora de la cita.
        /// </summary>
        public DateTime? HoraInicial { get; set; }
        /// <summary>
        /// Campo Descripcion, atributo para designar el motivo de cita y/o lo que se va a hacer.
        /// </summary>
        public string? Descripcion { get; set; }

        public virtual Mascota Mascotas { get; set; } = null!;
        public virtual Servicios Servicios { get; set; } = null!;
        public virtual Usuarios Usuario { get; set; } = null!;
    }
}
