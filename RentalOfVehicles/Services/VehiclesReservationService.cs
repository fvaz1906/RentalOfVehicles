using RentalOfVehicles.Data;
using RentalOfVehicles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalOfVehicles.Services
{
    public class VehiclesReservationService
    {
        private readonly DbRentalVehiclesContext _context;
        public VehiclesReservationService(DbRentalVehiclesContext context)
        {
            _context = context;
        }

        public Vehicles FindById(int id)
        {
            return _context.Vehicles.Where(obj => obj.Id == id).FirstOrDefault();
        }

        public async Task Insert(VehiclesReservation obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

    }
}
