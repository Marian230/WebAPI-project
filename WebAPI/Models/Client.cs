using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [Table("clients")]
    public class Client
    {
        [Key()]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("IP")]
        public string IP { get; set; }

        [Column("MAC")]
        public string MAC { get; set; }

        [Column("dateOfLogin")]
        public DateTime DateOfLogin { get; set; }
    }
}