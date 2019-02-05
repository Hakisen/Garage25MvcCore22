using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage25MvcCore22.Models
{
    public class Receipt
    {
        public int Id { get; set; }

        [Display(Name = "Reg. Nr.")]
        public string RegNr { get; set; }

        [Display(Name = "Customer")]
        public string MemberName { get; set; }

        [Display(Name = "Check In Time")]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        [Display(Name = "Chekc Out Time")]
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }

        [Display(Name = "Total Park Time")]
        [DataType(DataType.DateTime)]
        public DateTime Duration { get; set; }

        [Display(Name = "Total Price")]
        public int TotalPrice { get; set; }
    }
}
