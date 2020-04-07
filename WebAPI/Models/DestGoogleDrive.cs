using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [Table("destGoogleDrive")]
    public class DestGoogleDrive
    {
        [Key()]
        public int IdDestSource { get; set; }

        [Column("gmail")]
        public string Gmail { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("path")]
        public string Path { get; set; }

        [Column("fileSuffix")]
        public string fileSuffix { get; set; }
    }
}