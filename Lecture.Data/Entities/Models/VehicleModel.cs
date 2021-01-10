using System.Collections.Generic;
using Lecture.Data.Enums;

namespace Lecture.Data.Entities.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public VehicleType VehicleType { get; set; }

        public int BrandId { get; set; }
        public VehicleBrand Brand { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
