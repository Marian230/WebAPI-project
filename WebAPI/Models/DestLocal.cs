﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [Table("tbDestLocal")]
    public class DestLocal : ModelTemplate
    {
        [ForeignKey("DestSource")]
        public int IdDestSource { get; set; }

        [Column("path")]
        public string Path { get; set; }

        [Column("fileSuffix")]
        public string FileSuffix { get; set; }

        public DestSource DestSource { get; set; }
    }
}