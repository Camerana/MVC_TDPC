using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_TDPC13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_TDPC13.Controllers
{
    /*
    - Creare nella pagina Javascript.cshtml un nuovo tasto che
    chiami un endpoint di tipo GET GetTDPC13Data che restituisca
    un numero casuale.
    - Loggare in console e scrivere in pagina il risultato ottenuto 
    dall'endpoint
     
     */
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }
        public IActionResult ButtonPage()
        {
            return View();
        }
        public IActionResult Javascript()
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
