using System.Collections.Generic;

namespace Lecture.Data.Entities.Models
{
    public class VehicleBrand
    {
        public int Id { get; set; }
        public string Brand { get; set; }

        public ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
