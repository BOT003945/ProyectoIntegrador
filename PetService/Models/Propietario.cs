using System;
using System.Collections.Generic;

namespace PetService.Models
{
    public partial class Propietario
    {
        public Propietario()
        {
            Mascota = new HashSet<Mascota>();
        }

        public int IdPropietario { get; set; }
        /// <summary>
        /// Campo Nombres, indica uno o los dos nombres de las posibles usuarios.
        /// </summary>
        public string Nombres { get; set; } = null!;
        /// <summary>
        /// Campo ApellidoP, indica el apellido paterno del usuario.
        /// </summary>
        public string ApellidoP { get; set; } = null!;
        /// <summary>
        /// Campo ApellidoM, indica el apellido materno del usuario.
        /// </summary>
        public string ApellidoM { get; set; } = null!;
        /// <summary>
        /// Campo FechaNacimiento, indica su cumpleaños para calcular edad.
        /// </summary>
        public DateTime FechaNacimiento { get; set; }
        /// <summary>
        /// Campo Telefono, indica el telefono del usuario.
        /// </summary>
        public string Telefono { get; set; } = null!;
        /// <summary>
        /// Campo Sexo, indica el sexo del usuario.
        /// </summary>
        public string? Sexo { get; set; }
        public string? Direccion { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<Mascota> Mascota { get; set; }
    }
}
