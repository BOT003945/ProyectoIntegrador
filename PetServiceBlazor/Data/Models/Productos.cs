using System;
using System.Collections.Generic;

namespace PetServiceBlazor.Data.Models
{
    /// <summary>
    /// Tabla Producto, donde se almacena la información de cada producto a la venta.
    /// </summary>
    public partial class Productos
    {
        public Productos()
        {
            VentaDetalles = new HashSet<VentaDetalles>();
        }

        /// <summary>
        /// Campo IdProductos, llave primaria en la tabla de productos.
        /// </summary>
        public int IdProductos { get; set; }
        /// <summary>
        /// Campo FotoProducto, guarda la información (URL) para una foto del producto.
        /// </summary>
        public string? FotoProducto { get; set; }
        /// <summary>
        /// Campo NombreProducto, indica el nombre producto.
        /// </summary>
        public string NombreProducto { get; set; } = null!;
        /// <summary>
        /// Campo Descripcion, da una descripción de lo que hace o es el artículo.
        /// </summary>
        public string? Descripcion { get; set; }
        /// <summary>
        /// Campo Precio, precio del producto.
        /// </summary>
        public double Precio { get; set; }
        /// <summary>
        /// Campo Inventario, cantidad del producto disponible.
        /// </summary>
        public int Inventario { get; set; }

        public virtual ICollection<VentaDetalles> VentaDetalles { get; set; }
    }
}
