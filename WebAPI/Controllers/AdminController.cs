using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class AdminController : ControllerTemplate<Admin>
    {
        public override DbSet DbSet => this.Context.Admins;

        /*public void Put(Admin newAdmin)
        {
            var admin = this.DbSet.Find(newAdmin.Id);
            var adminN = this.Context.Admins.Find(newAdmin.Id);
            adminN = newAdmin;
            this.Context.SaveChanges();
        }*/
    }
}