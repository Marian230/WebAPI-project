using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [Table("tbSettings")]
    public class Setting : ModelTemplate
    {
        [Column("IdAdmin")]
        public int IdAdmin { get; set; }

        [Column("defaultMenuTable")]
        public int DefaultMenuTable { get; set; }
    }
}