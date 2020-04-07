using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public abstract class ControllerTemplate<T> : ApiController
    {
        public abstract DbSet DbSet { get; }

        protected MyContext Context { get; set; } = new MyContext();

        public IEnumerable<T> Get() // Return all
        {
            return (this.DbSet as IEnumerable<T>);
        }

        public T Get(int Id) // Return specific
        {
            return (T)this.DbSet.Find(Id);
        }

        public void Post([FromBody]T item) // Add
        {
            this.DbSet.Add(item);
            this.Context.SaveChanges();
        }

        public void Put(int id, T newItem) // Edit, tohle předělat
        {
            T item = (T)this.DbSet.Find(id);
            item = newItem;
            this.Context.SaveChanges();
        }

        public void Delete(int id)
        {
            T item = (T)this.DbSet.Find(id);
            this.Context.Set(typeof(T)).Remove(item);
            this.Context.SaveChanges();
        }
    }
}