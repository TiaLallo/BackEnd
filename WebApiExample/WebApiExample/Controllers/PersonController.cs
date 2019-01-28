using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiExample.Models;
using WebApiExample.Repositories;

namespace WebApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        // GET: api/person
        [HttpGet]
        public ActionResult<List<Person>> GetPersons()
        {
            return new JsonResult(_personRepository.Read());
        }

        // GET: api/person/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            return new JsonResult(_personRepository.Read(id));
        }

        //POST:api/person
        [HttpPost]
        public ActionResult<Person> Post(Person person)
        {
            var newPerson = _personRepository.Create(person);
            return newPerson;
        }

        //PUT:api/person/2
        [HttpPut("{id}")]
        public ActionResult<Person> Put(int id, Person person)
        {
            var updatedPerson = _personRepository.Update(person);
            return updatedPerson;
        }

        //DELETE:api/åerson/2
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _personRepository.Delete(id);
            return new NoContentResult();
        }
    }
}