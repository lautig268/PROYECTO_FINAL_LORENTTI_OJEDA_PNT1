using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROYECTO_FINAL_LORENTTI_OJEDA_PNT1.Data;
using PROYECTO_FINAL_LORENTTI_OJEDA_PNT1.Models;
using System.Diagnostics;

namespace PROYECTO_FINAL_LORENTTI_OJEDA_PNT1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AppDbContext context_;
        // GET: TiendaController

        public HomeController(AppDbContext context)
        {
            context_ = context;
        }

        [HttpPost]
        public IActionResult AgregarAlCarrito(int productoId)
        {
            if (Sesion.user == null)
            {
                return RedirectToAction("LogIn", "Usuario");
            }

            // 2? Validar que el usuario existe en BD
            var usuarioEnBD = context_.Usuario.Find(Sesion.user.ID);
            if (usuarioEnBD == null)
            {
                return RedirectToAction("LogIn", "Usuario");
            }

            // Buscar el carrito del usuario actual
            var carrito = context_.Carrito
                .Include(c => c.Items)
                .FirstOrDefault(c => c.UsuarioId == Sesion.user.ID); // Cambiar según tu lógica de usuario

            // Si el usuario no tiene carrito, lo creamos
            if (carrito == null)
            {
                carrito = new Carrito
                {
                    UsuarioId = Sesion.user.ID,
                    Items = new List<CarritoItem>() // ? importante
                };
                context_.Carrito.Add(carrito);
                context_.SaveChanges(); // guardamos para obtener el Id del carrito
            }

            // Buscamos el producto
            var producto = context_.Productos.Find(productoId);
            if (producto == null)
                return NotFound();

            // Verificar si ya existe el item en el carrito
            var item = carrito.Items.FirstOrDefault(i => i.ProductoId == productoId);
            if (item != null)
            {
                item.Cantidad += 1;
            }
            else
            {
                carrito.Items.Add(new CarritoItem
                {
                    ProductoId = productoId,
                    Cantidad = 1,
                    Precio = producto.Precio
                });
            }

            context_.SaveChanges();

            // Redirigimos de nuevo a Home (o donde corresponda)
            return RedirectToAction("Index");
        }

        public IActionResult Carrito() {
            //var idCarrito = context_.Carrito.FirstOrDefault(p=> p.Id == Sesion.user.ID).Id; 


            //var lista = context_.CarritoItems.Include(ci => ci.Producto).Where(p =>p.CarritoId == Sesion.user.ID).ToList();
            //ViewBag.Carritoo = lista;

            var carrito = context_.Carrito
       .Include(c => c.Items)
       .ThenInclude(i => i.Producto)
       .FirstOrDefault(c => c.UsuarioId == Sesion.user.ID);

            // Convertimos los Items (HashSet) a List para que acepte [i] en la vista
            if (carrito == null || carrito.Items == null || !carrito.Items.Any())
            {
                ViewBag.Carritoo = new List<CarritoItem>();
            }
            else
            {
                ViewBag.Carritoo = carrito.Items.ToList();
            }

            return View();
        }


        [HttpPost]
        public IActionResult Comprar()
        {
            // Obtener el carrito actual del usuario
            var carrito = context_.Carrito
                .Include(c => c.Items)
                .ThenInclude(i => i.Producto)
                .FirstOrDefault(c => c.UsuarioId == Sesion.user.ID);

            if (carrito == null || carrito.Items == null || !carrito.Items.Any())
            {
                TempData["Error"] = "El carrito está vacío.";
                return RedirectToAction("Carrito");
            }

            // Crear la compra
            var compra = new Compra
            {
                UsuarioId = Sesion.user.ID
            };

            context_.Compra.Add(compra);
            context_.SaveChanges(); // importante para obtener el Id de la compra

            // Crear los items de la compra
            foreach (var item in carrito.Items)
            {
                // Validar stock
                if (item.Producto.Stock < item.Cantidad)
                {
                    TempData["Error"] = $"No hay suficiente stock para {item.Producto.Nombre}.";
                    return RedirectToAction("Carrito");
                }

                // Descontar stock
                item.Producto.Stock -= item.Cantidad;

                // Crear item de compra
                var compraItem = new CompraItem
                {
                    CompraId = compra.Id,
                    ProductoId = item.ProductoId,
                    Cantidad = item.Cantidad
                };

                context_.CompraItem.Add(compraItem);
            }

            // Vaciar el carrito
            context_.CarritoItems.RemoveRange(carrito.Items);

            // Guardar todos los cambios
            context_.SaveChanges();

            
            return View("CompraExitosa");
        }

        public IActionResult Index()
        {

            ViewBag.Usuario = Sesion.user;
            ViewBag.productos = context_.Set<Producto>().ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
