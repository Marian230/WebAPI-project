using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class SettingsMailController : ControllerTemplate<SettingsMail>
    {
        public override DbSet DbSet => this.Context.SettingsMails;
    }
}