using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BreadSoft.Models
{
    public class Persona
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(100)]
        public string ApellidoMa { get; set; }
        [StringLength(100)]
        public string ApellidoPa { get; set; }
        [Required]
        [StringLength(100)]
        public string Domicilio { get; set; }
        [Required]
        [StringLength(16)]
        public string Telefono { get; set; }
        [Required]
        [StringLength(100)]
        public string Correo { get; set; }
    }
}