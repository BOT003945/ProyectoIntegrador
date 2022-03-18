using System;
using System.Collections.Generic;

namespace PetService.Models
{
    /// <summary>
    /// Tabla Venta_Detalle, donde se almacenan los detalles de cada venta.
    /// </summary>
    public partial class VentaDetalle
    {
        /// <summary>
        /// Campo IdVentaDetalle, llave primaria en la tabla Venta_Detalle.
        /// </summary>
        public int IdVentaDetalle { get; set; }
        /// <summary>
        /// Campo IdVenta, llave foránea que conecta con la tabla Venta.
        /// </summary>
        public int IdVenta { get; set; }
        /// <summary>
        /// Campo IdProducto, llave foránea que conecta con la tabla Producto.
        /// </summary>
        public int IdProducto { get; set; }
        /// <summary>
        /// Campo Descripcion, campo que describe el detalle del registro.
        /// </summary>
        public string Descripcion { get; set; } = null!;
        /// <summary>
        /// Campo Cantidad, campo que describe la cantidad de algún producto comprado.
        /// </summary>
        public int? Cantidad { get; set; }
        /// <summary>
        /// Campo Costo, campo que da el precio del producto, servicio, cita... Etc, al usuario.
        /// </summary>
        public double Costo { get; set; }

        public virtual Producto IdProductoNavigation { get; set; } = null!;
        public virtual Venta IdVentaNavigation { get; set; } = null!;
    }
}
