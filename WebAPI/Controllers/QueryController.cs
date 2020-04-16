using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            var query = (from j in Context.Jobs
                         join co in Context.Configurations on j.IdConfiguration equals co.Id
                         select new
                         {
                             IdClient = j.IdClient,
                             IdConfiguration = j.IdConfiguration,
                             Name = co.Name
                         });

            var myQuery = Context.Clients.GroupJoin(
                query,
                client => client.Id,
                q => q.IdClient,
                (client, q) => new
                {
                    Client = client,
                    Configuration = q
                })
                .SelectMany(
                x => x.Configuration.DefaultIfEmpty(),
                (x, y) => new
                {
                    ID = x.Client.Id,
                    Name = x.Client.Name,
                    IP = x.Client.IP,
                    MAC = x.Client.MAC,
                    Configuration = (y == null ? String.Empty : y.Name)
                });

            var returnQuery = myQuery
                .GroupBy(client => client.ID)
                .ToList()
                .Select(eg => new
                {
                    ID = eg.Key,
                    Name = eg.First().Name,
                    IP = eg.First().IP,
                    MAC = eg.First().MAC,
                    Configuration = string.Join(",", eg.Select(i => i.Configuration))
                });

            return returnQuery;
        }
    }
}