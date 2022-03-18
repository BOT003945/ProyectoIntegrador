﻿using System;
using System.Collections.Generic;

namespace PetService.Models
{
    /// <summary>
    /// Tabla Venta, donde se almacenan los registros de venta.
    /// </summary>
    public partial class Ventas
    {
        public Ventas()
        {
            VentaDetalles = new HashSet<VentaDetalles>();
        }

        /// <summary>
        /// Campo IdVenta, llave primaria en la tabla Venta.
        /// </summary>
        public int IdVenta { get; set; }
        /// <summary>
        /// Campo IdUsuario, llave foránea que conecta con la tabla Usuario.
        /// </summary>
        public int IdUsuario { get; set; }
        /// <summary>
        /// Campo Fecha, campo que guarda la fecha efectuada de la venta.
        /// </summary>
        public DateTime Fecha { get; set; }

        public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<VentaDetalles> VentaDetalles { get; set; }
    }
}