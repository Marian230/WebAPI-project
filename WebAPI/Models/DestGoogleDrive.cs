using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [Table("tbDestGoogleDrive")]
    public class DestGoogleDrive : ModelTemplate
    {
        public int IdDestSource { get; set; }

        [Column("gmail")]
        public string Gmail { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("path")]
        public string Path { get; set; }

        [Column("fileSuffix")]
        public string fileSuffix { get; set; }

        [ForeignKey("IdDestSource")]
        public DestSource DestSource { get; set; }
    }
}