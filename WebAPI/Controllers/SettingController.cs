using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class SettingController : ControllerTemplate<Setting>
    {
        public override DbSet DbSet => this.Context.Settings;
    }
}