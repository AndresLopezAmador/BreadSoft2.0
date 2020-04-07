using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BreadSoft.Models
{
    public class Producto
    {
        public int idPedido;
        public int cantidad;
        public double pago;
        public DateTime fechaPedido;
        public DateTime fechaEntrega;
        public int idProducto;
        public int idEmpleado;
        public int idCliente;
        public int idProveedor;
    }
}