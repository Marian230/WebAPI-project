using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/query")]
    public class QueryController : ApiController
    {
        private MyContext Context = new MyContext();

        [HttpGet]
        [Route("homequery")]
        public virtual object HomeQuery()
        {
            return (from cl in Context.Clients
                    join j in Context.Jobs on cl.Id equals j.IdClient
                    join c in Context.Configurations on j.IdConfiguration equals c.Id
                    select new
                    {
                        Id = cl.Id,
                        CLName = cl.Name,
                        COName = c.Name,
                        Desc = c.Description
                    }).ToList();
        }

        [HttpGet]
        [Route("clientquery")]
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
                    Id = eg.Key,
                    Name = eg.First().Name,
                    IP = eg.First().IP,
                    MAC = eg.First().MAC,
                    Configuration = string.Join(",", eg.Select(i => i.Configuration))
                });

            return returnQuery;
        }

        [HttpGet]
        [Route("completedbackups")]
        public virtual object CompletedBackupsQuery()
        {
            /*return (from job in Context.Jobs
                    join schedule in Context.Schedules on job.Id equals schedule.IdJob
                    join configuration in Context.Configurations on job.IdConfiguration equals configuration.Id
                    join client in Context.Clients on job.IdClient equals client.Id
                    where schedule.BackupDate < DateTime.Now
                    select new
                    {
                        Datum = schedule.BackupDate,
                        ClientName = client.Name,
                        ConfigurationName = configuration.Name,
                        Description = configuration.Description, 
                        Error = schedule.ErrorCode
                    }).ToList();*/

            return Context.Schedules
                .Where(schedule => schedule.IdJob == schedule.Job.Id)
                .Where(schedule => schedule.Job.Configuration.Id == schedule.Job.IdConfiguration)
                .Where(Schedule => Schedule.Job.Client.Id == Schedule.Job.IdClient)
                .Where(schedule => schedule.BackupDate < DateTime.Now)
                .Select(schedule => new
                {
                    Datum = schedule.BackupDate,
                    ClientName = schedule.Job.Client.Name,
                    ConfigurationName = schedule.Job.Configuration.Name,
                    schedule.Job.Configuration.Description,
                    Error = schedule.ErrorCode
                });
        }

        [HttpGet]
        [Route("incomingbackups")]
        public virtual object IncomingBackupsQuery()
        {
            return Context.Schedules
                .Where(schedule => schedule.IdJob == schedule.Job.Id)
                .Where(schedule => schedule.Job.Configuration.Id == schedule.Job.IdConfiguration)
                .Where(Schedule => Schedule.Job.Client.Id == Schedule.Job.IdClient)
                .Where(schedule => schedule.BackupDate >= DateTime.Now)
                .Select(schedule => new 
                {
                    Datum = schedule.BackupDate,  
                    ClientName = schedule.Job.Client.Name,
                    ConfigurationName = schedule.Job.Configuration.Name,
                    schedule.Job.Configuration.Description
                });
        }

        [HttpGet]
        [Route("newclients")]
        public virtual object NewClients()
        {
            return Context.Clients.Where(client => client.DateOfLogin == null).ToList();
        }
    }
}