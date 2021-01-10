using System.Collections.Generic;
using System.Linq;
using Lecture.Data.Entities;
using Lecture.Data.Entities.Models;
using Lecture.Domain.Enums;

namespace Lecture.Domain.Repositories
{
    public class CustomerRepository : BaseRepository
    {

        public CustomerRepository(RentACarDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(Customer customer)
        {
            DbContext.Customers.Add(customer);
            return SaveChanges();
        }

        public ResponseResultType Edit(Customer customer, int customerId)
        {
            var customerDb = DbContext.Customers.Find(customerId);
            if (customerDb == null)
            {
                return ResponseResultType.NotFound;
            }

            customerDb.Oib = customer.Oib;
            customerDb.FirstName = customer.FirstName;
            customerDb.LastName = customer.LastName;
            customerDb.DateOfBirth = customer.DateOfBirth;
            customerDb.DrivingLicenseIdentifier = customer.DrivingLicenseIdentifier;

            return SaveChanges();
        }

        public ResponseResultType Delete(int customerId)
        {
            var customer = DbContext.Customers.Find(customerId);
            if (customer == null)
            {
                return ResponseResultType.NotFound;
            }

            DbContext.Customers.Remove(customer);

            return SaveChanges();
        }

        public ICollection<Customer> GetAll()
        {
            return DbContext.Customers.ToList();
        }
    }
}
