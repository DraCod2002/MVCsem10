using MVCsem10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCsem10.Controllers
{
    public class ProductoController : Controller
    {
        public ActionResult Index()
        {
            List<Producto> productos = new List<Producto>();
            if (Session["productos"] == null)
            {
                productos.Add(new Producto { ProductoId = 1, Nombre = "Laptop", Precio = 1500.00m, descripcion = "Laptop de alta gama" });
                productos.Add(new Producto { ProductoId = 2, Nombre = "Smartphone", Precio = 800.00m, descripcion = "Teléfono inteligente" });
                productos.Add(new Producto { ProductoId = 3, Nombre = "Monitor", Precio = 300.00m, descripcion = "Monitor Full HD" });
                Session["productos"] = productos;
            }
            else
            {
                productos = (List<Producto>)Session["productos"];
            }
            return View(productos);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Producto());
        }

        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            
            if (Session["productos"] == null)
            {
                Session["productos"] = new List<Producto>(); 
            }

            List<Producto> productos = (List<Producto>)Session["productos"];
            producto.ProductoId = productos.Count + 1; 
            productos.Add(producto);
            Session["productos"] = productos;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<Producto> productos = (List<Producto>)Session["productos"];
            Producto producto = productos.FirstOrDefault(p => p.ProductoId == id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        [HttpPost]
        public ActionResult Edit(Producto productoEditado)
        {
            List<Producto> productos = (List<Producto>)Session["productos"];
            Producto productoOriginal = productos.FirstOrDefault(p => p.ProductoId == productoEditado.ProductoId);
            if (productoOriginal != null)
            {
                productoOriginal.Nombre = productoEditado.Nombre;
                productoOriginal.Precio = productoEditado.Precio;
                productoOriginal.descripcion = productoEditado.descripcion;
                Session["productos"] = productos; 
            }
            return RedirectToAction("Index");
        }
    }
}
