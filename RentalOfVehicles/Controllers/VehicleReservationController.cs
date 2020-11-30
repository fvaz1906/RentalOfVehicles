using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RentalOfVehicles.Data;
using RentalOfVehicles.Models;
using RentalOfVehicles.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalOfVehicles.Controllers
{
    public class VehicleReservationController : Controller
    {
        private readonly DbRentalVehiclesContext _context;
        private readonly VehiclesReservationService _vehiclesReservationService;
        ILogger _logger;

        public VehicleReservationController(DbRentalVehiclesContext context, VehiclesReservationService vehiclesReservationService, ILogger<VehiclesService> logger)
        {
            _context = context;
            _vehiclesReservationService = vehiclesReservationService;
            _logger = logger;
        }

        public IActionResult Create(int id)
        {
            _logger.LogInformation("Chamando metodo Create para retornar um formulário de reserva de veiculos");
            ViewData["id"] = id;
            ViewData["vehicle"] = _vehiclesReservationService.FindById(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,CPF,DateReservationInitial,DateReservationFinal,Date,VehiclesId")] VehiclesReservation vehiclesReservation)
        {
            _logger.LogInformation("Chamando metodo Create para adicionar uma reserva no banco de dados");
            if (ModelState.IsValid)
            {
                await _vehiclesReservationService.Insert(vehiclesReservation);
                return RedirectToAction("Index", "Vehicles");
            }
            return RedirectToAction("Index", "Vehicles");
        }

    }
}
