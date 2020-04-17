using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BreadSoft.Models
{
    public class Producto
    {
        public producto producto { get; set; }
        public byte[] Foto { get; internal set; }
    }
}