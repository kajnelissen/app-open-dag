using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OpenDagAppBackEnd.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Text { get; set; }

        public int SurveyId { get; set; }

        public Survey Survey { get; set; }

        //public virtual ICollection<Answer> Answers { get; set; }
    }
}