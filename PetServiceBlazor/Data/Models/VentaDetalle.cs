using System;
using System.Collections.Generic;
using PetServiceBlazor.Data.Models;

namespace PetServiceBlazor.Data.Models
{
    public partial class VentaDetalle
    {
        public int IdVentaDetalle { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public string Descripcion { get; set; } = null!;
        public int? Cantidad { get; set; }
        public double Costo { get; set; }

        public virtual Producto IdProductoNavigation { get; set; } = null!;
        public virtual Venta IdVentaNavigation { get; set; } = null!;
    }
}
