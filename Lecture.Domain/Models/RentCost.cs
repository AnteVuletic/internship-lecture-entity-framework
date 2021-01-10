using System;

namespace Lecture.Domain.Models
{
    public class RentCost
    {
        public int Id { get; set; }
        public DateTime StartOfRent { get; set; }
        public DateTime EndOfRent { get; set; }
        public string Vehicle { get; set; }
        public decimal Cost { get; set; }
        public string Rate { get; set; }
    }
}
