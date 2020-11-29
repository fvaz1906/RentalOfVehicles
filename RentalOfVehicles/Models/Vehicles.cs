using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalOfVehicles.Models
{
    public class Vehicles
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set; }
        public int AnoModelo { get; set; }
        public int AnoFabricacao { get; set; }

        public List<VehiclesReservation> VehiclesReservation { get; set; }
    }
}
