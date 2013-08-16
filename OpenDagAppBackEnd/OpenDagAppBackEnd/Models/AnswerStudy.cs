﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OpenDagAppBackEnd.Models
{
    public class AnswerStudy
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Answer")]
        public Guid AnswerID { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Study")]
        public Guid StudyID { get; set; }

        public Answer Answer { get; set; }
        public Study Study { get; set; }
        public int Rating { get; set; }
    }
}