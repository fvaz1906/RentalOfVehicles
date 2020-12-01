using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentalOfVehicles.Areas.Identity.Data;
using RentalOfVehicles.Data;

[assembly: HostingStartup(typeof(RentalOfVehicles.Areas.Identity.IdentityHostingStartup))]
namespace RentalOfVehicles.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<RentalOfVehiclesContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("RentalOfVehiclesContextConnection")));

                services.AddDefaultIdentity<RentalOfVehiclesUser>(options => 
                {
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.SignIn.RequireConfirmedAccount = false;
                }).AddEntityFrameworkStores<RentalOfVehiclesContext>();

            });
        }
    }
}