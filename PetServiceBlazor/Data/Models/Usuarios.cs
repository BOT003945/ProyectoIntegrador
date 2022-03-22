using System;
using System.Collections.Generic;

namespace PetServiceBlazor.Data.Models
{
    /// <summary>
    /// Tabla Usuario, donde se almacenan los diferentes tipos de servicios.
    /// </summary>
    public partial class Usuarios
    {
        public Usuarios()
        {
            //Cita = new HashSet<Citas>();
            //Mascota = new HashSet<Mascotas>();
            //Venta = new HashSet<Ventas>();
        }

        /// <summary>
        /// Campo IdUsuario, llave primaria en la tabla Usuario.
        /// </summary>
        public int IdUsuario { get; set; }
        /// <summary>
        /// Campo Nombres, indica uno o los dos nombres de las posibles usuarios.
        /// </summary>
        public string Nombres { get; set; } = default!; //No debe ser nulo.
        /// <summary>
        /// Campo ApellidoP, indica el apellido paterno del usuario.
        /// </summary>
        public string ApellidoP { get; set; } = null!;
        /// <summary>
        /// Campo ApellidoM, indica el apellido materno del usuario.
        /// </summary>
        public string? ApellidoM { get; set; }
        /// <summary>
        /// Campo FechaNacimiento, indica su cumpleaños para calcular edad.
        /// </summary>
        public DateTime? FechaNacimiento { get; set; }
        /// <summary>
        /// Campo Telefono, indica el telefono del usuario.
        /// </summary>
        public string Telefono { get; set; } = null!;
        /// <summary>
        /// Campo Direccion, guarda la dirección del hogar.
        /// </summary>
        public string? Direccion { get; set; }
        /// <summary>
        /// Campo Sexo, indica el sexo del usuario.
        /// </summary>
        public string? Sexo { get; set; }
        /// <summary>
        /// Campo Correo, indica el correo o email del usuario.
        /// </summary>
        public string Correo { get; set; } = null!;
        /// <summary>
        /// Campo Contra, indica la contraseña de la cuenta del usuario.
        /// </summary>
        public string Contra { get; set; } = null!;
        /// <summary>
        /// Campo FotoPerfil, foto del usario.
        /// </summary>
        public string? FotoPerfil { get; set; }
        /// <summary>
        /// Campo VerificacionEmail, es un código de seguridad enviado al email al guardar información, como seguridad.
        /// </summary>
        public string? VerificacionEmail { get; set; }
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

        public string? GetName()
        {
            return $"{Nombres} {ApellidoP} {ApellidoM}";
        }

        public virtual ICollection<Citas> Cita { get; set; }
        public virtual ICollection<Mascota> Mascota { get; set; }
        public virtual ICollection<Ventas> Venta { get; set; }
    }
}
