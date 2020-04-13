
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BreadSoft.Models;

namespace BreadSoft.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        public ActionResult Index()
        {
            var db = new BreadSoftv2Entities();
            var data = db.empleado.ToList();
            return View(data);
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int id)
        {
            EmpleadoPersona model = new EmpleadoPersona();
            model.empleado = new Consulta().mostrarInfo(id);
            model.persona = model.empleado.persona;
            return View(model );
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        [HttpPost]
        public ActionResult Create(empleado collection)
        {
            try
            {
                // TODO: Add insert logic here
                SqlParameter nombre = new SqlParameter("@nombre", collection.persona.nombre);
                SqlParameter aPaterno = new SqlParameter("@apellidoPaterno", collection.persona.apellidoPaterno);
                SqlParameter aMaterno = new SqlParameter("@apellidoMaterno", collection.persona.apellidoMaterno);
                SqlParameter domicilio = new SqlParameter("@domicilio", collection.persona.domicilio);
                SqlParameter telefono = new SqlParameter("@telefono", collection.persona.telefono);
                SqlParameter correo = new SqlParameter("@correoElectronico", collection.persona.correoElectronico);
                SqlParameter contrasenia = new SqlParameter("@contrasena", collection.contrasena);
                SqlParameter rol = new SqlParameter("@rol", collection.rol);

                var db = new BreadSoftv2Entities();
                var data = db.Database.ExecuteSqlCommand("insertarEmpleado @nombre , @apellidoPaterno , " +
                                                         "@apellidoMaterno , @domicilio , @telefono , " +
                                                         "@correoElectronico , @contrasena , @rol", nombre,
                                                         aPaterno, aMaterno, domicilio, telefono, correo,
                                                         contrasenia, rol);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Empleados/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Empleados/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
