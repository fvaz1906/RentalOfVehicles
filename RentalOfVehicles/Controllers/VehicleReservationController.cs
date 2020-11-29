using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalOfVehicles.Data;
using RentalOfVehicles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalOfVehicles.Controllers
{
    public class VehicleReservationController : Controller
    {
        private readonly DbRentalVehiclesContext _context;

        public VehicleReservationController(DbRentalVehiclesContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int id)
        {
            ViewData["id"] = id;
            ViewData["vehicle"] = _context.Vehicles.Where(obj => obj.Id == id).FirstOrDefault();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,CPF,DateReservationInitial,DateReservationFinal,Date,VehiclesId")] VehiclesReservation vehiclesReservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiclesReservation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Vehicles");
            }
            return RedirectToAction("Index", "Vehicles");
        }

    }
}
