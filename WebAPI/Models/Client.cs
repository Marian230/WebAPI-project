using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [Table("tbClients")]
    public class Client : ModelTemplate
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("IP")]
        public string IP { get; set; }

        [Column("MAC")]
        public string MAC { get; set; }

        [Column("dateOfLogin")]
        public DateTime? DateOfLogin { get; set; }
    }
}