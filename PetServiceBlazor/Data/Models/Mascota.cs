using System;
using System.Collections.Generic;

namespace PetServiceBlazor.Data.Models
{
    public partial class Mascota
    {
        public int IdMascota { get; set; }
        public string Nombre { get; set; } = null!;
        public string Sexo { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string? FotoMascota { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
