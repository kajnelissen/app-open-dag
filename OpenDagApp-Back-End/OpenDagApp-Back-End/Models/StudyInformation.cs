using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OpenDagApp_Back_End.Models
{
    public class StudyInformation
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int StudyId { get; set; }

        public Study Study { get; set; }
    }
}