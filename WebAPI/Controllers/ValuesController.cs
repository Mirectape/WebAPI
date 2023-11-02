using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.ContextFolder;
using WebAPI.Data;
using WebAPI.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IPersonData _personData; 

        public ValuesController(IPersonData personData)
        {
            _personData = personData;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _personData.GetPeople();
        }


        // GET api/values/5
        public Person GetPersonById(int id)
        {
            return _personData.GetPersonById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Person value)
        {
            _personData.AddPerson(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
             _personData.RemovePerson(_personData.GetPersonById(id));
        }

    }
}
