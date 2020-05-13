using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
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
        public virtual object HomeQuery(string token)
        {
            if (!AuthenticationController.CheckToken(token))
                return null;

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
        public virtual object ClientQuery(string token)
        {
            if (!AuthenticationController.CheckToken(token))
                return null;

            return Context.Clients
                .GroupJoin(Context.Jobs
                .Where(jobs => jobs.IdConfiguration == jobs.Configuration.Id),
                client => client.Id,
                q => q.IdClient,
                (client, q) => new
                {
                    Client = client,
                    Configuration = q
                })
                .SelectMany(x => x.Configuration
                .DefaultIfEmpty(),
                (x, y) => new
                {
                    x.Client.Id,
                    x.Client.Name,
                    x.Client.MAC,
                    Configuration = (y == null ? String.Empty : y.Configuration.Name)
                })
                .GroupBy(client => client.Id)
                .ToList()
                .Select(eg => new
                {
                    Id = eg.Key,
                    Name = eg.First().Name,
                    MAC = eg.First().MAC,
                    Configuration = string.Join(",", eg.Select(i => i.Configuration))
                });
        }

        [HttpGet]
        [Route("completedbackups")]
        public virtual object CompletedBackupsQuery(string token)
        {
            if (!AuthenticationController.CheckToken(token))
                return null;

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
        public virtual object IncomingBackupsQuery(string token)
        {
            if (!AuthenticationController.CheckToken(token))
                return null;

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
        public virtual object NewClients(string token)
        {
            if (!AuthenticationController.CheckToken(token))
                return null;

            return Context.Clients
                .Where(client => client.DateOfLogin == null).ToList();
        }

        [HttpGet]
        [Route("loggedclients")]
        public virtual object LoggedClients(string token)
        {
            if (!AuthenticationController.CheckToken(token))
                return null;

            return this.Context.Clients
                .Where(client => client.DateOfLogin != null).ToList();
        }

        [HttpGet]
        [Route("getclient/{MAC}")]
        public virtual object GetClient(string token, string MAC)
        {
            if (!AuthenticationController.CheckToken(token))
                return null;

            return this.Context.Clients
                .Where(client => client.MAC == MAC);
        }

        [HttpGet]
        [Route("getmyjobs/{mac}")]
        public virtual object GetMyJobs(string token, string mac)
        {
            if (!AuthenticationController.CheckToken(token))
                return null;

            return from job in this.Context.Jobs
                    join client in this.Context.Clients on job.IdClient equals client.Id
                    join configuration in this.Context.Configurations on job.IdConfiguration equals configuration.Id
                    from source in this.Context.Sources
                        .Where(source => configuration.Id == source.IdConfiguration)
                        .DefaultIfEmpty()
                    from destFtpServer in this.Context.DestFtpServers
                        .Where(destFtpServer => configuration.Id == destFtpServer.IdConfiguration)
                        .DefaultIfEmpty()
                    from destLocal in this.Context.DestLocals
                        .Where(destLocal => configuration.Id == destLocal.IdConfiguration)
                        .DefaultIfEmpty()
                    where client.MAC == mac
                    select new
                    {
                        configuration,
                        source,
                        destFtpServer,
                        destLocal
                    };
        }
    }
}