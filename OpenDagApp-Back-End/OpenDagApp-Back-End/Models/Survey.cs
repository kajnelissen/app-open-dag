using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OpenDagApp_Back_End.Models
{
    public class Survey
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        public bool Active { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}