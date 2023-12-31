﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PersonController : ApiController
    {
        [HttpGet]
        public IEnumerable<People> GetPeople()
        {
            using (PersonDBContext dbContext = new PersonDBContext())
            {
                return dbContext.People.ToList();
            }
        }

        public People GetPersonById(int id)
        {
            using (PersonDBContext dbContext = new PersonDBContext())
            {
                return dbContext.People.Where(p => p.ID == id).Single();
            }
        }

        [HttpPost]
        public void AddPerson([FromBody] People person)
        {
            using (PersonDBContext dbContext = new PersonDBContext())
            {
                dbContext.People.Add(person);
                dbContext.SaveChanges();
            }
        }

        [HttpDelete]
        public void RemovePerson(int id)
        {
            using (PersonDBContext dbContext = new PersonDBContext())
            {
                dbContext.People.Remove(dbContext.People.Where(p => p.ID == id).Single());
                dbContext.SaveChanges();
            }
        }

        [HttpPut]
        public void EditPerson(int id, People updatedPerson)
        {
            using (PersonDBContext dbContext = new PersonDBContext())
            {
                var editPerson = dbContext.People.Where((p) => p.ID == id).Single();
                editPerson.FirstName = updatedPerson.FirstName;
                editPerson.SecondName = updatedPerson.SecondName;
                editPerson.PhoneNumber = updatedPerson.PhoneNumber;
                editPerson.PaternalName = updatedPerson.PaternalName;
                editPerson.Address = updatedPerson.Address;
                editPerson.Description = updatedPerson.Description;
                dbContext.SaveChanges();
            }
        }
    }
}
