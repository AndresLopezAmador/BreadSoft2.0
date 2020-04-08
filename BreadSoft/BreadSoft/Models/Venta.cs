using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BreadSoft.Models
{
    public class Venta
    {
        public int IdVenta { get; set; }

        public Nullable<int> IdEmpleado { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public Nullable<int> IdProducto { get; set; }

        public int CantProducto { get; set; }
        public int MontoPagarV { get; set; }
        public DateTime FechaVenta { get; set; }

        public virtual Empleado NomEmpleado { get; set; }
        public virtual Cliente NomCliente { get; set; }
        public virtual Producto NomProducto { get; set; }
    }
}