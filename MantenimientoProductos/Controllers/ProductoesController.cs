using MantenimientoProductos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ServiceWCFCRUD;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MantenimientoProductos.Controllers
{
    public class ProductoesController : Controller
    {
        
        private Service1Client service1 = new Service1Client();

        // GET: Productoes
        public ActionResult Index()
        {
            try
            {
                var producto = service1.GetAllProductos(1);
                var p = producto;
                return View(producto);

            }
            catch (Exception exp)
            {
                throw;
            }
            
        }

        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                int id2 = Convert.ToInt32(id);
                Get_Producto_Result producto = service1.GetProducto(id2);
                return View(producto);
            }
            catch (Exception exp)
            {
                throw;
            }
        }

        // GET: Productoes/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.ID_Categoria = new SelectList((System.Collections.IEnumerable)service1.GetAllCat(), "Id", "Nombre");
                return View();
            }
            catch (Exception exp)
            {
                throw;
            }
        }

        // POST: Productoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Get_Producto_Result producto)
        {
            try
            {
                service1.CreateProd(producto.Imagen, producto.Descripción, producto.Precio_Compra, producto.Precio_Venta, producto.Stock, producto.ID_Categoria, producto.InfoProducto);
                return RedirectToAction("Index");
            }
            catch (Exception exp)
            {

                ViewBag.ID_Categoria = new SelectList((System.Collections.IEnumerable)service1.GetAllCat(), "Id", "Nombre");
                return View(producto);
            }
            


        }

        // GET: Productoes/Edit/5
        public ActionResult Edit(int? id)
        {

            try
            {
                int id2 = Convert.ToInt32(id);
                Get_Producto_Result producto = service1.GetProducto(id2);
                ViewBag.ID_Categoria = new SelectList((System.Collections.IEnumerable)service1.GetAllCat(), "Id", "Nombre");
                return View(producto);
            }
            catch (Exception exp)
            {
                throw;
            }
            
        }

        // POST: Productoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Get_Producto_Result producto)
        {
            try
            {
                service1.UpdateProdAsync(producto.Id,producto.Imagen, producto.Descripción, producto.Precio_Compra, producto.Precio_Venta, producto.Stock, producto.ID_Categoria, producto.InfoProducto);
                return RedirectToAction("Index");
            }
            catch (Exception exp)
            {

                ViewBag.ID_Categoria = new SelectList((System.Collections.IEnumerable)service1.GetAllCatAsync(), "Id", "Nombre");
                return View(producto);
            }
        }

        // GET: Productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                int id2 = Convert.ToInt32(id);
                Get_Producto_Result producto = service1.GetProducto(id2);
                ViewBag.ID_Categoria = new SelectList((System.Collections.IEnumerable)service1.GetAllCat(), "Id", "Nombre");
                return View(producto);
            }
            catch (Exception exp)
            {
                throw;
            }
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                int id2 = Convert.ToInt32(id);
                service1.DeleteProd(id2);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }           
        }
    }
}
