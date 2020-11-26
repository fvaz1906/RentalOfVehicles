using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentalOfVehicles.Models;

namespace RentalOfVehicles.Data
{
    public class DbRentalVehiclesContext : DbContext
    {
        public DbRentalVehiclesContext (DbContextOptions<DbRentalVehiclesContext> options)
            : base(options)
        {
        }

        public DbSet<RentalOfVehicles.Models.Vehicles> Vehicles { get; set; }
    }
}
