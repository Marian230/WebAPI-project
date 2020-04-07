using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [Table("destLocal")]
    public class DestLocal
    {
        [Key()]
        public int IdDestSource { get; set; }

        [Column("path")]
        public string Path { get; set; }

        [Column("fileSuffix")]
        public string FileSuffix { get; set; }
    }
}