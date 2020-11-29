using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentalOfVehicles.Areas.Identity.Data;
using RentalOfVehicles.Models;

namespace RentalOfVehicles.Data
{
    public class DbRentalVehiclesContext : DbContext
    {
        public DbRentalVehiclesContext (DbContextOptions<DbRentalVehiclesContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicles> Vehicles { get; set; }
        public DbSet<VehiclesReservation> VehiclesReservation { get; set; }
    }
}
