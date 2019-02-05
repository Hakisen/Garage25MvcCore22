using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage25MvcCore22.Models
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        // nav collection
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
