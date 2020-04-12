using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BreadSoft.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Usuario { get; set; }
        [Required]
        [StringLength(100)]
        public string Contrasenia { get; set; }
        [Required]
        [StringLength(100)]
        public string Rol { get; set; }
        public Persona Persona { get; set; }
    }
}