﻿using MVC_TDPC13.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_TDPC13.DB
{
    public class Repository
    {
        private DBContext DBContext;
        public Repository(DBContext DBContext)
        {
            this.DBContext = DBContext;
        }
        public List<Person> GetPersons()
        {
            List<Person> result = this.DBContext.Persons.ToList();
            return result;
        }
        public Person GetPersonByID(string id)
        {
            Person result = this.DBContext.Persons.Where(p => p.ID.ToString() == id).FirstOrDefault();
            return result;
        }
        public List<Person> GetPersonWithFilter(string filter)
        {
            List<Person> result = this.DBContext.Persons
                .Where(p => p.Nome.Contains(filter)
                || p.Cognome.Contains(filter)).ToList();
            return result;
        }
        public void InsertPerson(Person person)
        {
            this.DBContext.Persons.Add(person);
            this.DBContext.SaveChanges();
        }
    }
}
