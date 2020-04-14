using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BreadSoft.Models
{
    public class Consulta
    {
        BreadSoftv2Entities contexto = new BreadSoftv2Entities();

        public empleado mostrarInfo(int id) {
            try
            {
                //var info = from p in contexto.persona
                //           join v in contexto.empleado on p.idPersona equals v.idEmpleado
                //           where p.nombre == nombre
                //           select p;

                var info = from e in contexto.empleado
                           join p in contexto.persona on e.idPersona equals p.idPersona
                           where e.idEmpleado == id
                           select e;

                return info.FirstOrDefault();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //Detalles compra
        public compra mostrarICompra(int id)
        {
            try
            {
                var info = from e in contexto.compra
                           where e.idCompra == id
                           select e;

                return info.FirstOrDefault();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}