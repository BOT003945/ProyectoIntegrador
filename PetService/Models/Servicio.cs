using System;
using System.Collections.Generic;

namespace PetService.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            VentaDetalles = new HashSet<VentaDetalle>();
        }

        public int IdServicio { get; set; }
        public string NombreServicio { get; set; } = null!;

        public virtual ICollection<VentaDetalle> VentaDetalles { get; set; }
    }
}
