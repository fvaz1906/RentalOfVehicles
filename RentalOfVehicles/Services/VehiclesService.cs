using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Vehicles>> FindAllAsync()
        {
            return await _context.Vehicles.Include(obj => obj.VehiclesReservation).ToListAsync();
        }

        public async Task<Vehicles> FindById(int id)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Insert(Vehicles obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Vehicles obj)
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var obj = await _context.Vehicles.FindAsync(id);
            _context.Vehicles.Remove(obj);
            await _context.SaveChangesAsync();

        }

        public bool VehiclesExists(int id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
        }
    }
}
