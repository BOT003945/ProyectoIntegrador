using System;
using System.Collections.Generic;

namespace PetService.Models
{
    /// <summary>
    /// Tabla Rol, donde se indica los tipos de roles en  cuanto a usuarios o administadores.
    /// </summary>
    public partial class Rol
    {
        public Rol()
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
