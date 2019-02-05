using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage25MvcCore22.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var options = serviceProvider.GetRequiredService<DbContextOptions<Garage25MvcCore22Context>>();
            using (var context = new Garage25MvcCore22Context(options))
            {
                if (context.VehicleType.Any())
                {
                    return;
                    //context.VehicleType.RemoveRange(context.VehicleType);
                }

                // Let's seed!
                var vehicleTypes = new List<VehicleType>()
                    { new VehicleType() { Type = "Bicycle"},
                    new VehicleType() { Type = "Bus"},
                    new VehicleType() { Type = "Car" },
                    new VehicleType() { Type = "Motorcycle" },
                    new VehicleType() { Type = "PickupTruck" } };
                //people.Add(person);

                context.VehicleType.AddRange(vehicleTypes);
                context.SaveChanges();
            }
        }

    }
}
    

