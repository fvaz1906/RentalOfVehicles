using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public VehicleReservationController(DbRentalVehiclesContext context, VehiclesReservationService vehiclesReservationService)
        {
            _context = context;
            _vehiclesReservationService = vehiclesReservationService;
        }

        public IActionResult Create(int id)
        {
            ViewData["id"] = id;
            ViewData["vehicle"] = _vehiclesReservationService.FindById(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,CPF,DateReservationInitial,DateReservationFinal,Date,VehiclesId")] VehiclesReservation vehiclesReservation)
        {
            if (ModelState.IsValid)
            {
                await _vehiclesReservationService.Insert(vehiclesReservation);
                return RedirectToAction("Index", "Vehicles");
            }
            return RedirectToAction("Index", "Vehicles");
        }

    }
}
