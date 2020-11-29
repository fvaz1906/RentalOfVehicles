using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RentalOfVehicles.Data;
using RentalOfVehicles.Models;
using RentalOfVehicles.Services;

namespace RentalOfVehicles.Controllers
{
    public class VehiclesController : Controller
    {

        private readonly VehiclesService _vehiclesService;

        public VehiclesController(VehiclesService vehiclesService)
        {
            _vehiclesService = vehiclesService;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            return View(await _vehiclesService.FindAllAsync()); ;
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicles = await _vehiclesService.FindById(id.Value);

            if (vehicles == null)
            {
                return NotFound();
            }

            return View(vehicles);
        }

        // GET: Vehicles/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Modelo,Marca,Placa,AnoModelo,AnoFabricacao")] Vehicles vehicles)
        {
            if (ModelState.IsValid)
            {
                await _vehiclesService.Insert(vehicles);
                return RedirectToAction(nameof(Index));
            }
            return View(vehicles);
        }

        // GET: Vehicles/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicles = await _vehiclesService.FindById(id.Value);

            if (vehicles == null)
            {
                return NotFound();
            }

            return View(vehicles);
        }

        // POST: Vehicles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Modelo,Marca,Placa,AnoModelo,AnoFabricacao")] Vehicles vehicles)
        {
            if (id != vehicles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _vehiclesService.Update(vehicles);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_vehiclesService.VehiclesExists(vehicles.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicles);
        }

        // GET: Vehicles/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicles = await _vehiclesService.FindById(id.Value);

            if (vehicles == null)
            {
                return NotFound();
            }

            return View(vehicles);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _vehiclesService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
