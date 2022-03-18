using System;
using System.Collections.Generic;

namespace PetServiceBlazor.Data.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Usuarios = new HashSet<Usuario>();
        }

        /// <summary>
        /// Campo IdRol, llave primaria en la tabla roles.
        /// </summary>
        public int IdRol { get; set; }
        /// <summary>
        /// Campo NombreDescripcion, se indica el tipo de usuarios o administrador que pueda haber en el programa.
        /// </summary>
        public string NombreDescripcion { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
