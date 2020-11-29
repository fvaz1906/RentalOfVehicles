using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RentalOfVehicles.Areas.Identity.Data;
using RentalOfVehicles.Data;

namespace RentalOfVehicles.Services
{
    public static class SeedingService
    {
        public static void SeedUsers(UserManager<RentalOfVehiclesUser> userManager)
        {
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                var user = new RentalOfVehiclesUser
                {
                    UserName = "root",
                    Email = "root",
                    Name = "root",
                    Login = "root"
                };

                var password = "P@ssw0rd";

                var result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    return;
                }
            }
        }
    }
}
