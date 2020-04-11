using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [Table("settings")]
    public class Setting
    {
        [Key()]
        public int Id { get; set; }

        [Column("IdAdmin")]
        public int IdAdmin { get; set; }

        [Column("defaultMenuTable")]
        public int DefaultMenuTable { get; set; }

        /*public Admin Admin { get; set; }

        public SettingsMail SettingsMail { get; set; }

        public SettingsClient SettingsClient { get; set; }*/
    }
}