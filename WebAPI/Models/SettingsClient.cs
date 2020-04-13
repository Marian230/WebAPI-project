using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [Table("tbSettingsClient")]
    public class SettingsClient : ModelTemplate
    {
        public int IdSettings { get; set; }

        [Column("clientHistoryInterval")]
        public int ClientHistoryInterval { get; set; }

        [Column("clientHistoryIntervalUnits")]
        public int ClientHistoryIntervalUnits { get; set; }

        [ForeignKey("IdSettings")]
        public Setting Setting { get; set; }
    }
}