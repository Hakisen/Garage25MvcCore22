using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage25MvcCore22.Models;

namespace Garage25MvcCore22.Models
{
    public class Garage25MvcCore22Context : DbContext
    {
        public Garage25MvcCore22Context (DbContextOptions<Garage25MvcCore22Context> options)
            : base(options)
        {
        }

        public DbSet<Member> Member { get; set; }

        public DbSet<Vehicle> Vehicle { get; set; }

        public DbSet<VehicleType> VehicleType { get; set; }

        public DbSet<Receipt> Receipt { get; set; }
    }
}
