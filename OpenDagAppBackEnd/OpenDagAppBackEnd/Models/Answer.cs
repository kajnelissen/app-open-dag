using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OpenDagAppBackEnd.Models
{
    public class Answer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 1)]
        public string Text { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }

        public int studyId { get; set; }

        //public Study Study { get; set; }

        public int Rating { get; set; }
        //public IDictionary<Study, int> StudyRatings { get; set; }
    }
}