using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [Table("tbSource")]
    public class Source : ModelTemplate
    {
        public int IdConfiguration { get; set; }

        [Column("path")]
        public string Path { get; set; }

        [ForeignKey("IdConfiguration")]
        public Configuration Configuration { get; set; }
    }
}