using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_TDPC.Models;
using MVC_TDPC.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_TDPC.Controllers
{
    /*
    - creare un servizio che restituisca un numero casuale con:
        - interfaccia IRandomNumber
        - classe RandomNumberLessThan10 (numero casuale < 10)
        - classe RandomNumberGreaterThan50 (numero casuale > 50)
    - tramite dependency injection passare un oggetto di tipo
    IRandomNumber a HomeController
    - creare un endpoint RandomNumberPage in HomeController
    - tramite l'endpoint RandomNumberPage mostrare in una view il numero
    generato dal servizio
    - nello startup.cs configurare il servizio da usare (services.add..)
     */
    public class HomeController : Controller
    {
        private readonly IDBConnection DBConnection;
        private readonly IRandomNumber RandomNumber;

        public HomeController(IDBConnection DBConnection,
            IRandomNumber RandomNumber)
        {
            this.DBConnection = DBConnection;
            this.RandomNumber = RandomNumber;
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

        public IActionResult DBConnectionPage()
        {
            string result = this.DBConnection.Connect();
            DBConnectionModel model = new DBConnectionModel();
            model.DBConnectionResult = result;
            return View(model);
        }

        public IActionResult RandomNumberPage()
        {
            RandomNumberPageModel model = new RandomNumberPageModel();
            model.RandomNumber = RandomNumber.GenerateNumber();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
