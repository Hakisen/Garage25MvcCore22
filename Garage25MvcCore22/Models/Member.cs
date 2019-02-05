using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage25MvcCore22.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNr { get; set; }

        // nav. collection
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
