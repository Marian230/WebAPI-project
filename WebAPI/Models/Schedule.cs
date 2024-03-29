﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [Table("tbSchedule")]
    public class Schedule : ModelTemplate
    {
        public int IdJob { get; set; }

        [Column("backupDate")]
        public DateTime BackupDate { get; set; }

        [Column("errorCode")]
        public string ErrorCode { get; set; }

        [ForeignKey("IdJob")]
        public Job Job { get; set; }
    }
}