using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IPersonData
    {
        IEnumerable<Person> GetPeople();
        Person GetPersonById(int id);
        void AddPerson(Person person);
        void RemovePerson(Person person);

        /// <summary>
        /// To what id we put an updated person
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedPerson"></param>
        void EditPerson(int id, Person updatedPerson);
    }
}
