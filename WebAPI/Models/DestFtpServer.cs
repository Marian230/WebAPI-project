using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [Table("tbDestFtpServer")]
    public class DestFtpServer : ModelTemplate
    {
        public int IdConfiguration { get; set; }

        [Column("site")]
        public string Site { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("port")]
        public string Port { get; set; }

        [Column("fileSuffix")]
        public string FileSuffix { get; set; }

        [ForeignKey("IdConfiguration")]
        public Configuration Configuration { get; set; }
    }
}