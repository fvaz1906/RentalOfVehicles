using Microsoft.Extensions.Logging;
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
        ILogger _logger;
        public VehiclesReservationService(DbRentalVehiclesContext context, ILogger<VehiclesService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Vehicles FindById(int id)
        {
            _logger.LogInformation("Chamando metodo FindById para retornar um veiculo ao controlador.");
            return _context.Vehicles.Where(obj => obj.Id == id).FirstOrDefault();
        }

        public async Task Insert(VehiclesReservation obj)
        {
            _logger.LogInformation("Chamando metodo Insert adicionar um registro de reserva na base de dados.");
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

    }
}
