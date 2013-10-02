using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OpenDagAppBackEnd.Models
{
    public class NavigationRoute
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string Name { get; set; }

        public bool Active { get; set; }
        public virtual ICollection<NavigationTrack> Tracks { get; set; }
    }
}