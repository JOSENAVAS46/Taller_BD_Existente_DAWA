using System;
using System.Collections.Generic;

namespace Taller_BD_existente.Models
{
    public partial class Factura
    {
        public Factura()
        {
            DetalleFacturas = new HashSet<DetalleFactura>();
        }

        public int FacturaId { get; set; }
        public int? ClienteId { get; set; }
        public DateTime? Fecha { get; set; }
        public int? MetodoPagoId { get; set; }
        public string? Estado { get; set; }

        public virtual Cliente? Cliente { get; set; }
        public virtual MetodoPago? MetodoPago { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
