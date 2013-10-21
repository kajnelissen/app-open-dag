using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OpenDagAppBackEnd.Models
{
    public class TimeTableEntry
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [StringLength(120, MinimumLength = 1)]
        public string Description { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string Location { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public Boolean WholeDay { get; set; }

        public int TimeTableId { get; set; }

        public TimeTable TimeTable { get; set; }
    }
}