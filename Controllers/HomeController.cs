using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_TDPC13.DB;
using MVC_TDPC13.DB.Entities;
using MVC_TDPC13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_TDPC13.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Repository repository;
        public HomeController(ILogger<HomeController> logger, Repository repository)
        {
            _logger = logger;
            this.repository = repository;
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

        public IActionResult Persons()
        {
            List<Person> persons = this.repository.GetPersons();
            List<PersonModel> model = new List<PersonModel>();
            foreach (Person p in persons)
                model.Add(new PersonModel()
                {
                    Nome = p.Nome,
                    Cognome = p.Cognome
                });
            return View(model);
        }
        public IActionResult PersonByID()
        {
            Person person = this.repository.GetPersonByID("4CF2C67F-25D6-406C-A700-92EA796AFA57");
            PersonModel model = new PersonModel()
            {
                Nome = person.Nome,
                Cognome = person.Cognome
            };
            return View(model);
        }
        public IActionResult PersonsWithFilter()
        {
            List<Person> persons = this.repository.GetPersonWithFilter("sempr");
            List<PersonModel> model = new List<PersonModel>();
            foreach (Person p in persons)
                model.Add(new PersonModel()
                {
                    Nome = p.Nome,
                    Cognome = p.Cognome
                });
            return View(model);
        }
        public IActionResult InsertPerson()
        {
            Person person = new Person()
            {
                Nome = "Insert Nome",
                Cognome = "Insert Cognome",
                Stipendio = 1000000
            };
            this.repository.InsertPerson(person);
            return View(new PersonModel()
            {
                Nome = person.Nome,
                Cognome = person.Cognome
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
