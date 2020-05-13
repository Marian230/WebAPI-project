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
        public virtual IEnumerable<T> Get(string token) // Return all
        {
            if (AuthenticationController.CheckToken(token))
                return (this.DbSet as IEnumerable<T>);
            else
                return null;
        }

        [HttpGet]
        [Route("id:int")]
        public virtual T Get(string token, int Id) // Return specific
        {
            if (AuthenticationController.CheckToken(token))
                return (T)this.DbSet.Find(Id);
            else
                return null;
        }

        [HttpPost]
        [Route("item:T")]
        public virtual void Post(string token, T item) // Add
        {
            if (!AuthenticationController.CheckToken(token))
                return;

            if (item == null)
            return;

            this.DbSet.Add(item);
            this.Context.SaveChanges();
        }  

        [HttpPut]
        [Route("item:T")]
        public virtual void Put(string token, T item) // Edit
        {
            if (!AuthenticationController.CheckToken(token))
                return;

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
        public virtual void Delete(string token, int id)
        {
            if (!AuthenticationController.CheckToken(token))
                return;

            T item = (T)this.DbSet.Find(id);

            if (item == null)
                return;

            this.Context.Set(typeof(T)).Remove(item);
            this.Context.SaveChanges();
        }
    }
}