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

        public DbSet<Persona> Maestros { get; set; }

        public DbSet<Cliente> Alumnos { get; set; }

        //public DbSet<Secretaria> Secretaria { get; set; }
    }
}