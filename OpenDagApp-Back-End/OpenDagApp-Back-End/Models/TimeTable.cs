﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OpenDagApp_Back_End.Models
{
    public class TimeTable
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual ICollection<TimeTableEntry> TimeTableEntries { get; set; }
    }
}