using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [Table("settingsClient")]
    public class SettingsClient
    {
        [Key()]
        public int IdSettings { get; set; }

        [Column("clientHistoryInterval")]
        public int ClientHistoryInterval { get; set; }

        [Column("clientHistoryIntervalUnits")]
        public int ClientHistoryIntervalUnits { get; set; }
    }
}