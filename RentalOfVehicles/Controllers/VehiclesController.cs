using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RentalOfVehicles.Data;
using RentalOfVehicles.Models;
using RentalOfVehicles.Services;

namespace RentalOfVehicles.Controllers
{
    public class VehiclesController : Controller
    {

        private readonly VehiclesService _vehiclesService;
        ILogger _logger;

        public VehiclesController(VehiclesService vehiclesService, ILogger<VehiclesController> logger)
        {
            _vehiclesService = vehiclesService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Chamando metodo Index com listagem de veiculos -> GET: Vehicles");
            return View(await _vehiclesService.FindAllAsync()); ;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            _logger.LogInformation("Chamando metodo Details informacoees dos veiculos -> GET: Vehicles/Details/5");
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

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            _logger.LogInformation("Chamando metodo Create com formulario de cadastro de vículos -> GET: Vehicles/Create");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Modelo,Marca,Placa,AnoModelo,AnoFabricacao")] Vehicles vehicles)
        {
            _logger.LogInformation("Chamando metodo Create para adicionar um veículos a base de dados -> POST: Vehicles/Create ");
            if (ModelState.IsValid)
            {
                await _vehiclesService.Insert(vehicles);
                return RedirectToAction(nameof(Index));
            }
            return View(vehicles);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            _logger.LogInformation("Chamando metodo Edit para buscar o veiculo informado e retornar um formulario na view com os dados do veiculo -> GET: Vehicles/Edit/5");
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Modelo,Marca,Placa,AnoModelo,AnoFabricacao")] Vehicles vehicles)
        {
            _logger.LogInformation("Chamando metodo Edit para atualizar os registro do veiculo na base de dados -> POST: Vehicles/Edit/5");
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

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            _logger.LogInformation("Chamando metodo Delete para retornar uma tela de confirmação da exclusão -> GET: Vehicles/Delete/5");
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
            _logger.LogInformation("Chamando metodo DeleteConfirmed para confirmar a exclusão do veiculos -> GET: Vehicles/Delete/5");
            await _vehiclesService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
