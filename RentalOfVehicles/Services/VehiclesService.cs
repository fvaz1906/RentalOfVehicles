using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RentalOfVehicles.Data;
using RentalOfVehicles.Models;

namespace RentalOfVehicles.Services
{
    public class VehiclesService
    {
        private readonly DbRentalVehiclesContext _context;
        ILogger _logger;

        public VehiclesService(DbRentalVehiclesContext context, ILogger<VehiclesService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Vehicles>> FindAllAsync()
        {
            _logger.LogInformation("Chamando metodo FindAllAsync para retornar uma lista de veiculos ao controlador");
            return await _context.Vehicles.Include(obj => obj.VehiclesReservation).ToListAsync();
        }

        public async Task<Vehicles> FindById(int id)
        {
            _logger.LogInformation("Chamando metodo FindById para retornar um objeto veiculo ao controlador");
            return await _context.Vehicles.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Insert(Vehicles obj)
        {
            _logger.LogInformation("Chamando metodo Insert para inserir registro no banco de dados");
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Vehicles obj)
        {
            _logger.LogInformation("Chamando metodo Update para atualizar um registro no banco de dados");
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            _logger.LogInformation("Chamando metodo Remove para remover um registro no banco de dados");
            var obj = await _context.Vehicles.FindAsync(id);
            _context.Vehicles.Remove(obj);
            await _context.SaveChangesAsync();

        }

        public bool VehiclesExists(int id)
        {
            _logger.LogInformation("Chamando metodo VehiclesExists para verificar se o veiculo existe no banco de dados");
            return _context.Vehicles.Any(e => e.Id == id);
        }
    }
}
