using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetServiceBlazor.Data.Models
{
    public partial class Mascota
    {
        public int IdMascota { get; set; }

        [Required(ErrorMessage = "El nombre de la mascota es obligatorio.")]
        public string Nombre { get; set; } = null!;
        public string Sexo { get; set; } = null!;
        public decimal? Estatura { get; set; }
        public decimal? Peso { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? FotoMascota { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
