using Microsoft.AspNetCore.Mvc;
using MVCConciertosAnita.Models;
using MVCConciertosAnita.Services;

namespace MVCConciertosAnita.Controllers
{
    public class EventosController : Controller
    {
        private ServiceEventos service;

        public EventosController(ServiceEventos service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Evento> eventos = await
                this.service.GetEventos();

            ViewData["CATEGORIAS"] = await this.service.GetCategorias();
            return View(eventos);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int idcategoria)
        {
            List<Evento> eventos = await
                this.service.FindEventoCategoria(idcategoria);

            ViewData["CATEGORIAS"] = await this.service.GetCategorias();
            return View(eventos);
        }
    }
}
