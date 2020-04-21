using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/{controller}")]
    public abstract class ControllerTemplate<T> : ApiController where T : ModelTemplate
    {
        public abstract DbSet DbSet { get; }

        protected MyContext Context { get; set; } = new MyContext();

        [HttpGet]
        [Route("")]
        public virtual IEnumerable<T> Get() // Return all
        {
            return (this.DbSet as IEnumerable<T>);
        }

        [HttpGet]
        [Route("id:int")]
        public virtual T Get(int Id) // Return specific
        {
            return (T)this.DbSet.Find(Id);
        }

        [HttpPost]
        [Route("item:T")]
        public virtual void Post(T item) // Add
        {
            if (item == null)
                return;

            this.DbSet.Add(item);
            this.Context.SaveChanges();
        }  

        [HttpPut]
        [Route("item:T")]
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

        [HttpDelete]
        [Route("id:int")]
        public virtual void Delete(int id)
        {
            T item = (T)this.DbSet.Find(id);

            if (item == null)
                return;

            this.Context.Set(typeof(T)).Remove(item);
            this.Context.SaveChanges();
        }
    }
}