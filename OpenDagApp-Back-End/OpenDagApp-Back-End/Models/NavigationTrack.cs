using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenDagApp_Back_End.Models
{
    public class NavigationTrack
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public NavigationRoute Route { get; set; }

        public Byte[] Image { get; set; }
    }
}