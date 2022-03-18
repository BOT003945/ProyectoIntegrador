using System;
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
        /// <summary>
        /// Campo IdUsuario, llave foránea que conecta con la tabla de usuarios para señalar al propietario del animal.
        /// </summary>
        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Sexo { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        /// <summary>
        /// Campo FotoMascota, foto de la mascota.
        /// </summary>
        public string? FotoMascota { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<Cita> Cita { get; set; }
    }
}
