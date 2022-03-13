using System;
using System.Collections.Generic;

namespace PetService.Models
{
    public partial class Producto
    {
        public Producto()
        {
            VentaDetalles = new HashSet<VentaDetalle>();
        }

        public int IdProductos { get; set; }
        public string? FotoProducto { get; set; }
        public string NombreProducto { get; set; } = null!;
        public string? Descripcion { get; set; }
        public double Precio { get; set; }
        public int Inventario { get; set; }

        public virtual ICollection<VentaDetalle> VentaDetalles { get; set; }
    }
}
