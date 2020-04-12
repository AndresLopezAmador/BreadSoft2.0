using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BreadSoft.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Empresa { get; set; }
        public Persona Persona { get; set; }
    }
}