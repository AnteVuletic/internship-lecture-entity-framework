using System.Collections.Generic;

namespace Lecture.Data.Entities.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int Kilometers { get; set; }

        public int VehicleModelId { get; set; }
        public VehicleModel VehicleModel { get; set; }

        public ICollection<Registration> Registrations { get; set; }
        public ICollection<Rent> Rents { get; set; }
    }
}
