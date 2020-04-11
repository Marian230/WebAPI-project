using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]
    public class MyContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Configuration> Configurations { get; set; }

        public DbSet<DestFtpServer> DestFtpServers { get; set; }

        public DbSet<DestGoogleDrive> DestGoogleDrives { get; set; }

        public DbSet<DestLocal> DestLocals { get; set; }

        public DbSet<DestSource> DestSources { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<SettingsClient> SettingsClients { get; set; }

        public DbSet<SettingsMail> SettingsMails { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Source> Sources { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}