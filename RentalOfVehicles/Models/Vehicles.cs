using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentalOfVehicles.Models
{
    public class Vehicles
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Modelo { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Marca { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Placa { get; set; }
        public int AnoModelo { get; set; }
        public int AnoFabricacao { get; set; }

        public List<VehiclesReservation> VehiclesReservation { get; set; }
    }
}
