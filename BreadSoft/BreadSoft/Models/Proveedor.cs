using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BreadSoft.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string Empresa { get; set; }
        public Persona Persona { get; set; }
    }
}