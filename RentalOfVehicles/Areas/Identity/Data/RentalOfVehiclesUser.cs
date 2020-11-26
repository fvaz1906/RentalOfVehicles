using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RentalOfVehicles.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the RentalOfVehiclesUser class
    public class RentalOfVehiclesUser : IdentityUser
    {
        public string Name { get; set; }
        public string Login { get; set; }
    }
}
