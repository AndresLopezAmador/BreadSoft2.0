using BreadSoft.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace BreadSoft.Controllers
{
    public class ProductoController : Controller
    {
    
        // GET: Producto
        public ActionResult Index()
        {
            var db = new BreadSoftv2Entities();
            var data = db.producto.ToList();
            return View(data);
        }

        // GET: Producto/Detalles
        [HttpPost]
        public ActionResult Details(int id, Producto collection)
        {
            SqlParameter idProduc = new SqlParameter("@idProducto", collection.producto.idProducto);

            var db = new BreadSoftv2Entities();
            var data = db.Database.ExecuteSqlCommand("SELECT FROM producto WHERE idProduc=@idProducto");

            return RedirectToAction("Index");
        }

        // GET: Pedido/Detalles
        public ActionResult Details(int? id)
        {
            var db = new BreadSoftv2Entities();
            Pedido model = new Pedido();
            //model.idPedido = new Consulta().mostrarInfo(id);
            var data = db.producto.Find(id);
            var data1 = db.proveedor.Find(id);
            var data2 = db.cliente.Find(id);
            var data3 = db.empleado.Find(id);

            return View(data);
        }

        // GET: producto create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(producto collection, HttpPostedFileBase file)
        {
            //HttpPostedFileBase fb = Request.Files[0];
            try
            {
                //SqlParameter idProduc = new SqlParameter("@idProducto", collection.idProducto);
                string nombre = collection.nombre;
                string descripcion = collection.descripcion;
                int cantidad = collection.cantidad;
                decimal precio = collection.precio;
                byte[] array = null;

                Producto pro = new Producto();//Para que esta clase
                if (file != null)
                {
                    using (MemoryStream ms = new MemoryStream()) {
                        file.InputStream.CopyTo(ms);
                        array = ms.GetBuffer();                        
                    }
                }

                //WebImage image = new WebImage(file.InputStream);
                //pro.Foto = image.GetBytes();
                //var foto = collection.foto;

                using (BreadSoftv2Entities db = new BreadSoftv2Entities()) {
                    db.insertarProducto(nombre,descripcion,cantidad,precio,array);
                    db.SaveChanges();
                }

                //var db = new BreadSoftv2Entities();
                //var data = db.Database.ExecuteSqlCommand("INSERT INTO producto (idProducto,nombre,descripcion,cantidad,precio,foto) " +
                //    "VALUES (@idProducto,@nombre,@descripcion,@cantidad,@precio,@foto)");

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: producto editar
        public ActionResult Edit(int id)
        {
            var db = new BreadSoftv2Entities();
            SqlParameter idP = new SqlParameter("@id", id);
            var data = db.Database.SqlQuery<producto>("exec consultarProducto @id", idP);
            return View(data);
        }

        // POST: Producto editar
        [HttpPost]
        public ActionResult Edit(int id, producto collection, HttpPostedFileBase file)
        {
            try
            {
                string nombre = collection.nombre;
                string descripcion = collection.descripcion;
                int cantidad = collection.cantidad;
                decimal precio = collection.precio;
                int idProduc = collection.idProducto;
                byte[] array = null;
                

                Producto pro = new Producto();
                if (file != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        array = ms.GetBuffer();
                    }
                }

                //WebImage image = new WebImage(fb.InputStream);
                //pro.Foto = image.GetBytes();
                //SqlParameter foto = new SqlParameter("@Foto", collection.foto);

                using (BreadSoftv2Entities db = new BreadSoftv2Entities())
                {
                    db.modificarProducto(nombre, descripcion,cantidad,precio,array,idProduc);
                    db.SaveChanges();
                }

                //    var db = new BreadSoftv2Entities();
                //var data = db.Database.ExecuteSqlCommand("UPDATE producto SET nombre=@nombre, descripcion=@descripcion, cantidad=@cantidad, precio=@precio, foto=@oto, WHERE idProduc=@idProducto");

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto eliminar
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Producto eliminar
        [HttpPost]
        public ActionResult Delete(int id, producto collection)
        {
            try
            {
                SqlParameter idProduc = new SqlParameter("@idProducto", collection.idProducto);

                var db = new BreadSoftv2Entities();
                var data = db.Database.ExecuteSqlCommand("DELETE producto WHERE idProduc=@idProducto");

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //obtener Imagen
        public ActionResult GetImage(int id)
        {
            var db = new BreadSoftv2Entities();
            var pro = db.producto.Find(id);
            byte[] byteImagen = pro.foto;

            MemoryStream memmorystream = new MemoryStream(byteImagen);
            Image image = Image.FromStream(memmorystream);

            memmorystream = new MemoryStream();
            image.Save(memmorystream, ImageFormat.Jpeg);
            memmorystream.Position = 0;

            return File(memmorystream, "imagen/jpg");
        }
    }
}