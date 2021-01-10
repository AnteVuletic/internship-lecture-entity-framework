using System;

namespace Lecture.Domain.Models
{
    public class RentDurationByModel
    {
        public string VehicleModel { get; set; }
        public TimeSpan RentSpan { get; set; }
    }
}
