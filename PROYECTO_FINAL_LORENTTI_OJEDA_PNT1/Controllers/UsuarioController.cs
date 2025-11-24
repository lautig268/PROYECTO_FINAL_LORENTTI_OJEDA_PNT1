using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Identity.Client;
using PROYECTO_FINAL_LORENTTI_OJEDA_PNT1.Data;
using PROYECTO_FINAL_LORENTTI_OJEDA_PNT1.Models;

namespace PROYECTO_FINAL_LORENTTI_OJEDA_PNT1.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AppDbContext context_;

        public UsuarioController(AppDbContext context)
        {
            context_ = context;
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            return View();
        }

     


        [HttpPost]
        public ActionResult LogInPost(string email, string contrasena)
        {
            Usuario usu = context_.Usuario.FirstOrDefault<Usuario>(u => u.Email == email);
            if (usu != null && usu.Contrasena == contrasena)
            {
                Sesion.user = usu;
                return RedirectToAction("Index", "Home");
            }



            return RedirectToAction("LogIn");
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterPost(string email, string contrasena, string telefono, string nombre)
        {

            var usuarioExistente = context_.Usuario.FirstOrDefault(u => u.Email == email);
            if (usuarioExistente != null)
            {
                // Opcional: agregar un mensaje de error para la vista
                TempData["Error"] = " ";
                return RedirectToAction("Register");
            }
            Usuario u = new Usuario { Email = email, Contrasena = contrasena, Nombre = nombre, Telefono = telefono };
            context_.Usuario.Add(u);
            context_.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Logout()
        {
            Sesion.user = new Usuario();
            return RedirectToAction("Index", "Home");
        }



    }
}