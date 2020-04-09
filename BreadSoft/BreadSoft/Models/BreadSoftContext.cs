using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BreadSoft.Models
{
    public class BreadSoftContext : DbContext
    {
        private const string NameOrConnectionString = "DefaultConnection";

        public BreadSoftContext() : base(NameOrConnectionString)
        {

        }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Proveedor> Proveedores { get; set; }

        public DbSet<Venta> Ventas { get; set; }

    }
}