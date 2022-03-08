using PetServiceBlazor.Data.Models;
using System;
using System.Collections.Generic;

namespace PetServiceBlazor.Data.Models
{
    public partial class Cita
    {
        public int IdCitas { get; set; }
        public int IdPropietario { get; set; }
        public int IdPerro { get; set; }
        public DateTime Fecha { get; set; }
        public string? Descripcion { get; set; }

        public virtual Mascota IdPerroNavigation { get; set; } = null!;
        public virtual Propietario IdPropietarioNavigation { get; set; } = null!;
    }
}
