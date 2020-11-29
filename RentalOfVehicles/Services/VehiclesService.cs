using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalOfVehicles.Data;
using RentalOfVehicles.Models;

namespace RentalOfVehicles.Services
{
    public class VehiclesService
    {
        private readonly DbRentalVehiclesContext _context;

        public VehiclesService(DbRentalVehiclesContext context)
        {
            _context = context;
        }

        public List<Vehicles> FindAll()
        {
            return _context.Vehicles.ToList();
        }
    }
}
