using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_TDPC13.Models;
using MVC_TDPC13.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_TDPC13.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDBConnection DBConnection;

        public HomeController(IDBConnection DBConnection)
        {
            this.DBConnection = DBConnection;
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

        public IActionResult DBConnectionPage()
        {
            string result = this.DBConnection.Connect();
            DBConnectionModel model = new DBConnectionModel();
            model.DBConnectionResult = result;
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
