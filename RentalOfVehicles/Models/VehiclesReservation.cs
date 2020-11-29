using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalOfVehicles.Models
{
    public class VehiclesReservation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateReservationInitial { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateReservationFinal { get; set; }

        public int VehiclesId { get; set; }

    }
}
