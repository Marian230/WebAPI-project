using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class QueryController : ApiController
    {
        private MyContext Context = new MyContext();

        [HttpGet]
        public virtual object HomeQuery()
        {
            return (from cl in Context.Clients
                    join j in Context.Jobs on cl.Id equals j.IdClient
                    join c in Context.Configurations on j.IdConfiguration equals c.Id
                    select new
                    {
                        CLName = cl.Name,
                        COName = c.Name,
                        Desc = c.Description
                    }).ToList();
        }

        [HttpGet]
        public virtual object ClientQuery()
        {
            //var testx = new JwtSecurityToken();

            var query = (from j in Context.Jobs
                         join c in Context.Configurations on j.IdConfiguration equals c.Id
                         select new
                         {
                             IdClient = j.IdClient,
                             IdConfiguration = j.IdConfiguration,
                             Name = c.Name
                         });

            return (from c in Context.Clients
                    join q in query on c.Id equals q.IdClient into leftOrder
                    from order in leftOrder.DefaultIfEmpty()
                    select new
                    {
                        ID = c.Id,
                        Name = c.Name,
                        IP = c.IP,
                        MAC = c.MAC,
                        Configuration = (order == null ? String.Empty : order.Name)
                    }).ToList();
        }
    }
}