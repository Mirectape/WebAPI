using System;
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

        public void AddPerson(People person)
        {
            using (PersonDBContext dbContext = new PersonDBContext())
            {
                dbContext.People.Add(person);
                dbContext.SaveChanges();
            }
        }

        public void RemovePerson(People person)
        {
            using (PersonDBContext dbContext = new PersonDBContext())
            {
                dbContext.People.Remove(person);
                dbContext.SaveChanges();
            }
        }

        public void EditPerson(int id, People updatedPerson)
        {
            using (PersonDBContext dbContext = new PersonDBContext())
            {
                var editPerson = dbContext.People.Where((p) => p.ID == id).Single();
                editPerson = updatedPerson;
                dbContext.SaveChanges();
            }
        }
    }
}
