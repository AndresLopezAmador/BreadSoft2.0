using BreadSoft.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BreadSoft.Controllers
{
    public class ComprasController : Controller
    {
        // GET: Compras
        public ActionResult Index()
        {
            var db = new BreadSoftv2Entities2();
            var data = db.compra.ToList();
            return View(data);
        }

        // GET: Compras/Detalles
        [HttpPost]
        public ActionResult Details(int id, compra collection)
        {
            SqlParameter idCompra = new SqlParameter("@idCompra", collection.idCompra);

            var db = new BreadSoftv2Entities2();
            var data = db.Database.ExecuteSqlCommand("SELECT FROM compra WHERE idCompra=@idCompra");

            return RedirectToAction("Index");

            /*Compras model = new Compras();
            model.compra = new Consulta().mostrarICompra(id);
            model.compra = model.compra;
            return View(model);*/
        }

        // GET: Compras create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        [HttpPost]
        public ActionResult Create(compra collection)
        {
            try
            {                
                SqlParameter fechaCompra = new SqlParameter("@fechaCompra", collection.fechaCompra);
                SqlParameter total = new SqlParameter("@total", collection.total);
                SqlParameter idEmpleado = new SqlParameter("@idEmpleado", collection.idEmpleado);                

                var db = new BreadSoftv2Entities2();
                var data = db.Database.ExecuteSqlCommand("INSERT INTO compra (fechaCompra,total,idEmpleado) VALUES (@fechaCompra,@total,@idEmpleado)");

                /*var data = db.Database.ExecuteSqlCommand("insertarCompra @fechaCompra , @total , " +
                                                        "@idEmpleado", fechaCompra, total, idEmpleado);*/

                return RedirectToAction("Index");                
            }
            catch
            {
                return View();
            }
        }

        // GET: Compras editar
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Compras editar
        [HttpPost]
        public ActionResult Edit(int id, compra collection)
        {
            try
            {
                SqlParameter idCompra = new SqlParameter("@idCompra", collection.idCompra);
                SqlParameter fechaCompra = new SqlParameter("@fechaCompra", collection.fechaCompra);
                SqlParameter total = new SqlParameter("@total", collection.total);
                SqlParameter idEmpleado = new SqlParameter("@idEmpleado", collection.idEmpleado);

                var db = new BreadSoftv2Entities2();
                var data = db.Database.ExecuteSqlCommand("UPDATE compra SET fechaCompra=@fechaCompra,total=@total,idEmpleado=@idEmpleado WHERE idCompra=@idCompra");
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compras eliminar
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Compras eliminar
        [HttpPost]
        public ActionResult Delete(int id, compra collection)
        {
            try
            {
                SqlParameter idCompra = new SqlParameter("@idCompra", collection.idCompra);

                var db = new BreadSoftv2Entities2();
                var data = db.Database.ExecuteSqlCommand("DELETE compra WHERE idCompra=@idCompra");

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}