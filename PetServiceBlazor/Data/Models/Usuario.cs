using System;
using System.Collections.Generic;

namespace PetServiceBlazor.Data.Models
{
    /// <summary>
    /// Tabla Usuario, donde se almacenan los diferentes tipos de servicios.
    /// </summary>
    public partial class Usuario
    {
        public Usuario()
        {
            Cita = new HashSet<Cita>();
            Propietarios = new HashSet<Propietario>();
            Venta = new HashSet<Venta>();
        }

        /// <summary>
        /// Campo IdUsuario, llave primaria en la tabla Usuario.
        /// </summary>
        public int IdUsuario { get; set; }
        /// <summary>
        /// Campo Correo, indica el correo o email del usuario.
        /// </summary>
        public string Correo { get; set; } = null!;
        /// <summary>
        /// Campo Contra, indica la contraseña de la cuenta del usuario.
        /// </summary>
        public string Contra { get; set; } = null!;
        /// <summary>
        /// Campo VerificacionEmail, es un código de seguridad enviado al email al guardar información, como seguridad.
        /// </summary>
        public string? VerificacionEmail { get; set; }
        /// <summary>
        /// Campo FotoPerfil, foto del usario.
        /// </summary>
        public string? FotoPerfil { get; set; }
        /// <summary>
        /// Campo RememberToken, usado como código de seguridad para recuperar la cuenta o cambiar contraseña.
        /// </summary>
        public string? RememberToken { get; set; }
        /// <summary>
        /// Campo FechaCreacion, almacena la fecha de creación de la cuenta.
        /// </summary>
        public DateTime? FechaCreacion { get; set; }
        /// <summary>
        /// Campo FechaActualizacion, almacena la fecha de actualización de la cuenta.
        /// </summary>
        public DateTime? FechaActualizacion { get; set; }
        /// <summary>
        /// Campo IdRol, llave foránea que conecta con la tabla Rol.
        /// </summary>
        public int IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; } = null!;
        public virtual ICollection<Cita> Cita { get; set; }
        public virtual ICollection<Propietario> Propietarios { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
