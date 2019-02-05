using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Garage25MvcCore22.Models
{
    public class VehicleType
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [NotMapped]
        public ICollection<VehicleType> VehicleTypes { get; set; }

        // nav collection
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
