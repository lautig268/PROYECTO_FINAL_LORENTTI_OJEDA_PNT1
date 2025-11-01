using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROYECTO_FINAL_LORENTTI_OJEDA_PNT1.Data;
using PROYECTO_FINAL_LORENTTI_OJEDA_PNT1.Models;

namespace PROYECTO_FINAL_LORENTTI_OJEDA_PNT1.Controllers
{
    public class TiendaController : Controller
    {
        private readonly AppDbContext context_;
        // GET: TiendaController

        public TiendaController(AppDbContext context)
        {
        context_ = context;
        }
        public ActionResult Index()
        {
            ViewBag.productos = context_.Set<Producto>().ToList();

            return View();
        }

        // GET: TiendaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TiendaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiendaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TiendaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TiendaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TiendaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TiendaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
