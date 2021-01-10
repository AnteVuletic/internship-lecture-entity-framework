using System;

namespace Lecture.Domain.Models
{
    public class EmployeeLastRent
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime LastRent { get; set; }
    }
}
