﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage25MvcCore22.Models
{
    public class VehicleOverviewViewModel
    {
        public Member Member { get; set; }
        public VehicleType VehicleType { get; set; }
        public string RegNr { get; set; }
       public DateTime StartTime { get; set; }
        //public TimeSpan Duration { get; set; }
    }
}