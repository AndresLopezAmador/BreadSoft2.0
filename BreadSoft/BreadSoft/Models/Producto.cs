using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BreadSoft.Models
{
    public class Producto
    {

        public int Id;
        [Required]
        [StringLength(100)]
        public string Nombre;
        [Required]
        [StringLength(100)]
        public string Descripcion;
        [Required]
        public int Cantidad;
        [Required]
        public double Precio;
        public long Foto;
        public Proveedor Proveedor { get; set; }
    }
}