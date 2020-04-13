using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [Table("tbDestSource")]
    public class DestSource : ModelTemplate
    {
        [Column("idConfiguration")]
        public int IdConfiguration { get; set; }
    }
}