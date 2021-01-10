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
    public class VehicleRepository : BaseRepository
    {
        public VehicleRepository(RentACarDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(int kilometers, int vehicleModelId)
        {
            var vehicleModel = DbContext.VehicleModels.Find(vehicleModelId);
            if (vehicleModel == null)
            {
                return ResponseResultType.NotFound;
            }

            var vehicle = new Vehicle
            {
                Kilometers = kilometers,
                VehicleModel = vehicleModel
            };

            DbContext.Vehicles.Add(vehicle);
            return SaveChanges();
        }

        public (ResponseResultType response, int newKilometeres) AddKilometers(int kilometersPassed, int vehicleId)
        {
            var vehicle = DbContext.Vehicles.Find(vehicleId);
            if (vehicle == null)
            {
                return (ResponseResultType.NotFound, -1);
            }

            vehicle.Kilometers += kilometersPassed;
            var response = SaveChanges();
            return (response, vehicle.Kilometers);
        }

        public ResponseResultType Delete(int vehicleId)
        {
            var vehicle = DbContext.Vehicles.Find(vehicleId);
            if (vehicle == null)
            {
                return ResponseResultType.NotFound;
            }

            DbContext.Vehicles.Remove(vehicle);
            return SaveChanges();
        }

        public ICollection<Vehicle> GetAll()
        {
            return DbContext.Vehicles
                .Include(v => v.VehicleModel)
                .ThenInclude(vm => vm.Brand)
                .ToList();
        }

        public ICollection<Vehicle> GetAllAvailable()
        {
            return DbContext.Vehicles
                .Include(v => v.VehicleModel)
                .ThenInclude(vm => vm.Brand)
                .Where(v => v.Rents.All(r => r.EndOfRent < DateTime.Now))
                .ToList();
        }

        public ICollection<Vehicle> GetAllWithExpiredRegistration()
        {
            return DbContext.Vehicles
                .Include(v => v.VehicleModel)
                .ThenInclude(vm => vm.Brand)
                .Where(v => v.Registrations.All(r => r.DateOfRegistration.AddYears(1) < DateTime.Now))
                .ToList();
        }

        public ICollection<Vehicle> GetAllExpiringByMonth(int monthsToExpire)
        {
            return DbContext.Vehicles
                .Include(v => v.VehicleModel)
                .ThenInclude(vm => vm.Brand)
                .Where(v => v.Registrations.Any(r => r.DateOfRegistration.AddYears(1) < DateTime.Now.AddMonths(monthsToExpire) && r.DateOfRegistration.AddYears(1) > DateTime.Now))
                .ToList();
        }

        public ICollection<CountByVehicleType> GetCountByVehicleTypes()
        {
            return DbContext.Vehicles
                .GroupBy(v => v.VehicleModel.VehicleType)
                .Select(g => new CountByVehicleType
                {
                    VehicleType = g.Key,
                    Count = g.Count()
                })
                .ToList();
        }

        public ICollection<CountByBrand> GetCountByBrands()
        {
            return DbContext.Vehicles
                .GroupBy(v => new { v.VehicleModel.Brand.Id, v.VehicleModel.Brand.Brand })
                .Select(g => new CountByBrand
                {
                    Brand = g.Key.Brand,
                    Count = g.Count()
                })
                .ToList();
        }
    }
}
