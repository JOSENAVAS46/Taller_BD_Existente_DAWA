using System;
using System.Collections.Generic;

namespace Taller_BD_existente.Models
{
    public partial class DetalleFactura
    {
        public int DetalleFacturaId { get; set; }
        public int? FacturaId { get; set; }
        public int? ProductoServicioId { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public string? Estado { get; set; }

        public virtual Factura? Factura { get; set; }
        public virtual ProductoServicio? ProductoServicio { get; set; }
    }
}
