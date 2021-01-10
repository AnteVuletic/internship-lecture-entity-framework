using System;
using System.Collections.Generic;
using Lecture.Data.Enums;

namespace Lecture.Data.Entities.Models
{
    public class RentRate
    {
        public int Id { get; set; }
        public RentRateType RentRateType { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Cost { get; set; }

        public ICollection<Rent> Rents { get; set; }
    }
}
