using WebAPI.ContextFolder;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class PersonData : IPersonData
    {
        private readonly DataContext _context;

        public PersonData(DataContext context)
        {
            _context = context;
        }

        public void AddPerson(Person person)
        {
            _context.People.Add(person);
            _context.SaveChanges();
        }

        public void RemovePerson(Person person)
        {
            _context.People.Remove(person);
            _context.SaveChanges();
        }

        public void EditPerson(int id, Person updatedPerson)
        {
            var editPerson = _context.People.Where((p) => p.ID == id).Single();
            editPerson = updatedPerson;
            _context.SaveChanges();
        }

        public IEnumerable<Person> GetPeople()
        {
            return _context.People;
        }

        public Person GetPersonById(int id)
        {
            return new DataContext().People.Where(p => p.ID == id).Single();
        }
    }
}
