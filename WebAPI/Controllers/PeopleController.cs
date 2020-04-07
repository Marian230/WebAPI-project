using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PeopleController : ApiController
    {
        private MyContext context = new MyContext();

        // GET: api/People
        public IEnumerable<Person> Get()
        {
            return this.context.People;
        }

        // GET: api/People/5
        public Person Get(int id)
        {
            return this.context.People.Find(id);
        }

        // POST: api/People
        public void Post([FromBody]Person person)
        {
            this.context.People.Add(person);
            this.context.SaveChanges();
        }

        // PUT: api/People/5
        public void Put(int id, [FromBody]Person person)
        {
            Person current = this.context.People.Find(id);

            current.Name = person.Name;
            current.Surname = person.Surname;
            current.Age = person.Age;

            this.context.SaveChanges();
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {
            Person person = this.context.People.Find(id);

            this.context.People.Remove(person);
            this.context.SaveChanges();
        }
    }
}
