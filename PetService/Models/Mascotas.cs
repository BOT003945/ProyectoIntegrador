using System;
using System.Collections.Generic;

namespace PetService.Models
{
    public partial class Mascotas
    {
        public int IdMascota { get; set; }
        public string Nombre { get; set; } = null!;
        public string Sexo { get; set; } = null!;
        public decimal? Estatura { get; set; }
        public decimal? Peso { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? FotoMascota { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuarios? IdUsuarioNavigation { get; set; }
    }
}
