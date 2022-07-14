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
    /*
     esercizio:
        - aggiungere un API controller con una post che crei una Person
        su DB prendendo i dati dall'input dell'utente nel frontend
    passi:
        - creare database con nome arbitrario
        - creare tabella Persons
        - creare la connection string nell'appsettings.json
        - importare i pacchetti nuget necessari (guardare nelle 
        dependencies di questo progetto)
        - creare il DBContext
        - creare la Repository
        - registrare i servizi necessari in Startup.cs
        (dbcontext, repository)
        - creare un API controller con la post di insert
            - esempio nel branch MVCeAPI nel PersonController
        - creare in una view un form di insert con n textbox e un button di insert
        - creare una funzione js collegata al button di insert che
        chiami l'endpoint post del controller
        - nell'endpoint del controller chiamare l'insert della repository
            - esempio nel branch EntityFramework in HomeController
     */
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
                    ID = p.ID.ToString(),
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
                ID = person.ID.ToString(),
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
                    ID = p.ID.ToString(),
                    Nome = p.Nome,
                    Cognome = p.Cognome
                });
            return View(model);
        }
        public IActionResult InsertPerson()
        {
            /*
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
            */
            return View();
        }

        public IActionResult UpdatePerson()
        {
            List<Person> persons = this.repository.GetPersons();
            List<PersonModel> model = new List<PersonModel>();
            foreach (Person p in persons)
                model.Add(new PersonModel()
                {
                    ID = p.ID.ToString(),
                    Nome = p.Nome,
                    Cognome = p.Cognome
                });
            return View(model);
        }

        public IActionResult DeletePerson()
        {
            List<Person> persons = this.repository.GetPersons();
            List<PersonModel> model = new List<PersonModel>();
            foreach (Person p in persons)
                model.Add(new PersonModel()
                {
                    ID = p.ID.ToString(),
                    Nome = p.Nome,
                    Cognome = p.Cognome
                });
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
