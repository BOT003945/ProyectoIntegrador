using System;
using System.Collections.Generic;

namespace PetService.Models
{
    /// <summary>
    /// Tabla Mascota, donde se almacena la información de la mascota.
    /// </summary>
    public partial class Mascota
    {
        public Mascota()
        {
            Cita = new HashSet<Cita>();
        }

        /// <summary>
        /// Campo IdMascota, llave principal de la tabla.
        /// </summary>
        public int IdMascota { get; set; }
        /// <summary>
        /// Campo Nombre, indica el nombre del animal.
        /// </summary>
        public string Nombre { get; set; } = null!;
        /// <summary>
        /// Campo Sexo, indica el sexo de la mascota.
        /// </summary>
        public string Sexo { get; set; } = null!;
        /// <summary>
        /// Campo FechaNacimiento, indica la edad de la mascota y su fecha de nacimiento.
        /// </summary>
        public DateTime? FechaNacimiento { get; set; }
        /// <summary>
        /// Campo IdUsuario, llave foránea que conecta con la tabla de usuarios para señalar al propietario del animal.
        /// </summary>
        public int IdUsuario { get; set; }
        public string? FotoMascota { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<Cita> Cita { get; set; }
    }
}
