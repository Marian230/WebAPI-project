using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [Table("tbJob")]
    public class Job : ModelTemplate
    {
        [Column("idClient")]
        public int IdClient { get; set; }

        [Column("idConfiguration")]
        public int IdConfiguration { get; set; }

        [ForeignKey("IdClient")]
        public Client Client { get; set; }

        [ForeignKey("IdConfiguration")]
        public Configuration Configuration { get; set; }
    }
}