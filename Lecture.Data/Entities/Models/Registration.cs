using System;

namespace Lecture.Data.Entities.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public DateTime DateOfRegistration { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
