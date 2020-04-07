using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [Table("job")]
    public class Job
    {
        [Key()]
        public int Id { get; set; }

        [Column("idClient")]
        public int IdClient { get; set; }

        [Column("idConfiguration")]
        public int IdConfiguration { get; set; }
    }
}