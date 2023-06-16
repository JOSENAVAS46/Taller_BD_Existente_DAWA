using System;
using System.Collections.Generic;

namespace Taller_BD_existente.Models
{
    public partial class MetodoPago
    {
        public MetodoPago()
        {
            Facturas = new HashSet<Factura>();
        }

        public int MetodoPagoId { get; set; }
        public string? Nombre { get; set; }
        public string? Estado { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
