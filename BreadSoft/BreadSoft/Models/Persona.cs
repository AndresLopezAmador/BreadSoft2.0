﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BreadSoft.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoMa { get; set; }
        public string ApellidoPa { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}