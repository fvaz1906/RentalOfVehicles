﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentalOfVehicles.Areas.Identity.Data;
using RentalOfVehicles.Models;

namespace RentalOfVehicles.Data
{
    public class RentalOfVehiclesContext : IdentityDbContext<RentalOfVehiclesUser>
    {
        public RentalOfVehiclesContext(DbContextOptions<RentalOfVehiclesContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
