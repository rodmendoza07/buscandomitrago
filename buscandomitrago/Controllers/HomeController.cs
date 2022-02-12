using buscandomitrago.Models;
using buscandomitrago.Servicios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace buscandomitrago.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBebidas _bebidas;
        public HomeController(ILogger<HomeController> logger, IBebidas bebida)
        {
            _logger = logger;
            _bebidas = bebida;
        }

        public async Task<ActionResult> Index()
        {
            LBebida lista = await _bebidas.ObtenerBebidas("margarita");
            return View(lista);
        }
       
        [HttpPost]
        public async Task<PartialViewResult> SearchByName([FromBody] Bebida b)
        {
            LBebida lista = await _bebidas.ObtenerBebidas(b.strDrink);
            return PartialView(lista);
        }

        public async Task<PartialViewResult> SearchByIngredient([FromBody] Bebida b)
        {
            LBebida lista = await _bebidas.ObetenerBebidasIngredientes(b.strIngredient1);
            return PartialView(lista);
        }
    }
}
