using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [Table("tbAdmin")]
    public class Admin : ModelTemplate
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("surname")]
        public string Surname { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("e-mail")]
        public string Email { get; set; }

        [Column("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}