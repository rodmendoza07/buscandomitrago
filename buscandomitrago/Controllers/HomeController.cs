﻿using buscandomitrago.Models;
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
       
        public async Task<PartialViewResult> SearchByName(string nombre)
        {
            LBebida lista = await _bebidas.ObtenerBebidas(nombre);
            return PartialView(lista);
        }

        public async Task<PartialViewResult> SearchByIngredient(string ingrediente)
        {
            LBebida lista = await _bebidas.ObetenerBebidasIngredientes(ingrediente);
            return PartialView();
        }
    }
}
