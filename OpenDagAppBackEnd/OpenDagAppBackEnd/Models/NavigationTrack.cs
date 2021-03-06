﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenDagAppBackEnd.Models
{
    public class NavigationTrack
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public NavigationRoute Route { get; set; }

        public string FileName { get; set; }

        public string Image { get; set; }
    }
}