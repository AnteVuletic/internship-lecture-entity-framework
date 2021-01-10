using System.Collections.Generic;

namespace Lecture.Data.Entities.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public ICollection<Rent> Rents { get; set; }
    }
}
