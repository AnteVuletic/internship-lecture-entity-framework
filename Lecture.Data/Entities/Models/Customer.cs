using System;
using System.Collections.Generic;

namespace Lecture.Data.Entities.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Oib { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DrivingLicenseIdentifier { get; set; }

        public ICollection<Rent> Rents { get; set; }
    }
}
