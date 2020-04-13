using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [Table("tbConfiguration")]
    public class Configuration : ModelTemplate
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("backupType")]
        public string BackupType { get; set; }

        [Column("cron")]
        public string Cron { get; set; }

        [Column("repeatableBackup")]
        public bool RepeatableBackup { get; set; }

        [Column("savedBackupsNumber")]
        public int SavedBackupNumber { get; set; }

        //public DestSource DestSource { get; set; }

        //public List<Job> Jobs { get; set; }
    }
}