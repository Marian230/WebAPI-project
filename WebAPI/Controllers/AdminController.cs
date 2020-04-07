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
        public override DbSet DbSet => this.context.Admins;

        private MyContext context = new MyContext();
    }
}