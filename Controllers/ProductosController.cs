using Microsoft.AspNetCore.Mvc;
using proyecto_powermas.Models;
using proyecto_powermas.Modulos;

namespace proyecto_powermas.Controllers
{
    public class ProductosController : Controller
    {
        private productoDAO _productos = new productoDAO();

        // GET: ProductosController
        public ActionResult Index()
        {
            var productos = _productos.Listado();
            return View(productos);
        }

        public IActionResult Listado()
        {
            var productos = _productos.Listado();
            return Json(productos);
        }


        // POST: ProductosController/Create
        [HttpPost]
        public ActionResult Create([FromBody] Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
            }

            try
            {
                _productos.Agregar(producto);
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        // POST: ProductosController/Edit
        [HttpPost]
        public ActionResult Edit([FromBody] Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
            }

            try
            {
                _productos.Actualizar(producto);
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        // POST: ProductosController/Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var producto = _productos.Buscar(id);
            if (producto == null)
            {
                return Json(new { success = false, error = "Producto no encontrado" });
            }

            try
            {
                _productos.Eliminar(id);
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false, error = "Error al eliminar el producto" });
            }
        }


        public IActionResult ObtenerProducto(int id)
        {
            var producto = _productos.Buscar(id);
            return Json(producto);
        }

    }
}
