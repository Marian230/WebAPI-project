using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [Table("destSource")]
    public class DestSource
    {
        [Key()]
        public int Id { get; set; }

        [Column("idConfiguration")]
        public int IdConfiguration { get; set; }

        //public Configuration Configuration { get; set; }

        public List<Source> Sources { get; set; }

        public List<DestFtpServer> DestFtpServers { get; set; }

        public List<DestGoogleDrive> DestGoogleDrives { get; set; }

        public List<DestLocal> DestLocals { get; set; }
    }
}