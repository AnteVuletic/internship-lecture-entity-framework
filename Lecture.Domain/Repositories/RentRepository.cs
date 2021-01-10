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
    public class RentRepository : BaseRepository
    {
        public RentRepository(RentACarDbContext dbContext) : base(dbContext)
        {
        }

        public (ResponseResultType Result, string Message) Add(DateTime startDate, DateTime endDate, int vehicleId, int rentRateId,
            int employeeId, int customerId)
        {
            if (endDate < startDate)
            {
                return (ResponseResultType.ValidationError, "End date cannot be before start date");
            }

            var vehicle = DbContext.Vehicles.Find(vehicleId);
            var rentRate = DbContext.RentRates.Find(rentRateId);
            var employee = DbContext.Employees.Find(employeeId);
            var customer = DbContext.Customers.Find(customerId);

            if (vehicle == null || rentRate == null || employee == null || customer == null)
            {
                var errors = new List<string>();

                if (vehicle == null)
                    errors.Add("vehicle");

                if (rentRate == null)
                    errors.Add("rent rate");

                if (employee == null)
                    errors.Add("employee");

                if (customer == null)
                    errors.Add("customer");

                var errorMessage = "Values not found for: " + string.Join(',', errors);
                return (ResponseResultType.NotFound, errorMessage);
            }

            var rent = new Rent
            {
                Customer = customer,
                Employee = employee,
                RentRate = rentRate,
                Vehicle = vehicle,
                StartOfRent = startDate,
                EndOfRent = endDate
            };

            DbContext.Rents.Add(rent);
            var result = SaveChanges();
            if (result == ResponseResultType.Success)
            {
                return (result, "Successfully added rent");
            }

            return (result, "No changes made");
        }


        public ResponseResultType Delete(int rentId)
        {
            var rent = DbContext.Rents.Find(rentId);
            if (rent == null)
            {
                return ResponseResultType.NotFound;
            }

            DbContext.Rents.Remove(rent);
            return SaveChanges();
        }

        public ICollection<Rent> GetAll()
        {
            return DbContext.Rents
                .Include(r => r.Vehicle)
                .ThenInclude(v => v.VehicleModel)
                .ThenInclude(v => v.Brand)
                .Include(r => r.Employee)
                .ToList();
        }

        public ICollection<Rent> GetByEmployee(int take, int employeeId)
        {
            return DbContext.Rents
                .Include(r => r.Vehicle)
                .ThenInclude(v => v.VehicleModel)
                .ThenInclude(v => v.Brand)
                .Include(r => r.Employee)
                .Where(r => r.EmployeeId == employeeId)
                .Take(take)
                .ToList();
        }

        public RentCost GetRentCost(int rentId)
        {
            return DbContext.Rents
                .Where(r => r.EndOfRent.HasValue)
                .Select(r => new RentCost
                {
                    Id = r.Id,
                    EndOfRent = r.EndOfRent.Value,
                    StartOfRent = r.StartOfRent,
                    Cost = r.RentRate.Cost * ((decimal)(r.EndOfRent.Value - r.StartOfRent).Days * 2),
                    Vehicle =
                        $"Id: {r.Vehicle.Id} Kilometers: {r.Vehicle.Kilometers}km Model {r.Vehicle.VehicleModel.Model}",
                    Rate = $"Rate: {r.RentRate.RentRateType} Cost: {r.RentRate.Cost}"
                })
                .FirstOrDefault(r => r.Id == rentId);
        }


        public ICollection<CountRentsByDate> GetCountRentsByMonthByYear(int year)
        {
            if (DateTime.Now.Year < year)
            {
                return new List<CountRentsByDate>();
            }

            var numberMonths = DateTime.Now.Year == year
                ? DateTime.Now.Month
                : 12;

            var dates = Enumerable.Range(1, numberMonths).Select(monthDigit => new DateTime(year, monthDigit, 1));

            var rentsByYearAndMonth = DbContext.Rents
                .Where(r => r.EndOfRent.HasValue && r.EndOfRent.Value.Year == year)
                .ToList()
                .GroupBy(r => new { r.EndOfRent.Value.Year, r.EndOfRent.Value.Month })
                .ToDictionary(r => r.Key, r => r.Count());

            return dates.Select(date =>
            {
                var hasCount = rentsByYearAndMonth.TryGetValue(new { date.Year, date.Month }, out var count);
                return new CountRentsByDate
                {
                    Date = date,
                    Count = hasCount ? count : 0
                };
            })
            .ToList();
        }
    }
}
