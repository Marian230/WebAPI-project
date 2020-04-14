using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public abstract class ControllerTemplate<T> : ApiController where T : ModelTemplate
    {
        public abstract DbSet DbSet { get; }

        protected MyContext Context { get; set; } = new MyContext();

        public virtual IEnumerable<T> Get() // Return all
        {
            return (this.DbSet as IEnumerable<T>);
        }

        public virtual T Get(int Id) // Return specific
        {
            return (T)this.DbSet.Find(Id);
        }

        public virtual void Post([FromBody]T item) // Add
        {
            if (item == null)
                return;

            this.DbSet.Add(item);
            this.Context.SaveChanges();
        }  

        public virtual void Put(T item) // Edit
        {
            if (item == null)
                return;

            T tmp = Context.Set<T>().Find(item.Id);

            if (tmp == null)
                return;

            this.Context.Entry(tmp).CurrentValues.SetValues(item);
            this.Context.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            T item = (T)this.DbSet.Find(id);

            if (item == null)
                return;

            this.Context.Set(typeof(T)).Remove(item);
            this.Context.SaveChanges();
        }

        [HttpGet]
        [Route("api/main")]
        public virtual object HomeQuery()
        {
            return (from cl in Context.Clients
                    join j in Context.Jobs on cl.Id equals j.IdClient
                    join c in Context.Configurations on j.IdConfiguration equals c.Id
                    select new
                    {
                        CLName = cl.Name,
                        COname = c.Name,
                        Desc = c.Description
                    }).ToList();

            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(query, Newtonsoft.Json.Formatting.Indented);
            //return json;
        }
    }
}