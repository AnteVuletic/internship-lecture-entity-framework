using System;
using System.Collections.Generic;
using System.Linq;
using Lecture.Data.Entities;
using Lecture.Data.Entities.Models;
using Lecture.Domain.Enums;
using Lecture.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Lecture.Domain.Repositories
{
    public class EmployeeRepository : BaseRepository
    {
        public EmployeeRepository(RentACarDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(Employee employee)
        {
            DbContext.Employees.Add(employee);
            return SaveChanges();
        }

        public ResponseResultType Edit(Employee employee, int employeeId)
        {
            var employeeDb = DbContext.Customers.Find(employeeId);
            if (employeeDb == null)
            {
                return ResponseResultType.NotFound;
            }

            employeeDb.FirstName = employee.FirstName;
            employeeDb.LastName = employee.LastName;

            return SaveChanges();
        }

        public ResponseResultType Delete(int employeeId)
        {
            var employee = DbContext.Employees.Find(employeeId);
            if (employee == null)
            {
                return ResponseResultType.NotFound;
            }

            DbContext.Employees.Remove(employee);

            return SaveChanges();
        }

        public ICollection<Employee> GetAll()
        {
            return DbContext.Employees.ToList();
        }

        public ICollection<EmployeeLastRent> GetEmployeeLastRents()
        {
            return DbContext.Employees
                .Where(e => e.Rents.Any())
                .Select(e => new EmployeeLastRent
                {
                    Id = e.Id,
                    FullName = e.FirstName + " " + e.LastName,
                    LastRent = e.Rents.Max(r => r.EndOfRent ?? default)
                })
                .ToList();
        }
    }
}
