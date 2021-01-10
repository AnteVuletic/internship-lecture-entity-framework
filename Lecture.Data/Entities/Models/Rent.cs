using System;

namespace Lecture.Data.Entities.Models
{
    public class Rent
    {
        public int Id { get; set; }
        public DateTime StartOfRent { get; set; }
        public DateTime? EndOfRent { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public int RentRateId { get; set; }
        public RentRate RentRate { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
