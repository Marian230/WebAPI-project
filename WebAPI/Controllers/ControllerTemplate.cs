using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public abstract class ControllerTemplate<T> : ApiController
    {
        public abstract DbSet DbSet { get; }

        public IEnumerable<T> Get()
        {
            return (this.DbSet as IEnumerable<T>);
        }

        public T Get(int Id)
        {
            return (T)this.DbSet.Find(Id);
        }
    }
}