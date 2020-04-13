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
        public int idClient { get; set; }

        [Column("idConfiguration")]
        public int idConfiguration { get; set; }

        /*public Schedule Schedule { get; set; }*/

        [ForeignKey("idClient")]
        public Client Client { get; set; }

        [ForeignKey("idConfiguration")]
        public Configuration Configuration { get; set; }
    }
}