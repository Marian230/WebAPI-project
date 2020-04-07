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
    }
}