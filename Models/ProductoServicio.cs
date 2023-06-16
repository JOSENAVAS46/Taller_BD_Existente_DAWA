using System;
using System.Collections.Generic;

namespace Taller_BD_existente.Models
{
    public partial class ProductoServicio
    {
        public ProductoServicio()
        {
            DetalleFacturas = new HashSet<DetalleFactura>();
        }

        public int ProductoServicioId { get; set; }
        public string? Nombre { get; set; }
        public decimal? Precio { get; set; }
        public string? Estado { get; set; }

        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
