using System;
using System.Collections.Generic;
using System.Linq;
using Lecture.Data.Entities;
using Lecture.Data.Entities.Models;
using Lecture.Data.Enums;
using Lecture.Domain.Enums;
using Lecture.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Lecture.Domain.Repositories
{
    public class VehicleModelRepository : BaseRepository
    {
        public VehicleModelRepository(RentACarDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(VehicleType vehicleType, string model, int vehicleBrandId)
        {
            var doesVehicleModelAlreadyExist = GetDoesVehicleAlreadyExist(vehicleType, vehicleBrandId, model);

            if (doesVehicleModelAlreadyExist)
            {
                return ResponseResultType.AlreadyExists;
            }

            var vehicleBrand = DbContext.VehicleBrands.Find(vehicleBrandId);

            if (vehicleBrand == null)
            {
                return ResponseResultType.NotFound;
            }

            var vehicleModel = new VehicleModel
            {
                Brand = vehicleBrand,
                Name = model,
                VehicleType = vehicleType
            };

            DbContext.VehicleModels.Add(vehicleModel);
            return SaveChanges();
        }

        public ResponseResultType Delete(int vehicleModelId)
        {
            var vehicleModel = DbContext.VehicleModels.Find(vehicleModelId);
            if (vehicleModel == null)
            {
                return ResponseResultType.NotFound;
            }

            DbContext.VehicleModels.Remove(vehicleModel);
            return SaveChanges();
        }

        public ICollection<VehicleModel> GetAll()
        {
            return DbContext.VehicleModels
                .Include(vm => vm.Brand)
                .ToList();
        }

        public ICollection<RentDurationByModel> GetCountByModelBiggerThenAverage()
        {
            var averageMilliseconds = DbContext.Rents
                .Where(r => r.EndOfRent.HasValue)
                .Average(r => EF.Functions.DateDiffMillisecond(r.StartOfRent, r.EndOfRent));

            var aboveAverageRentVehicles = DbContext.Vehicles
                .Include(v => v.Rents)
                .Include(v => v.VehicleModel)
                .ThenInclude(vm => vm.Brand)
                .Where(v => v.Rents.Average(r => EF.Functions.DateDiffMillisecond(r.StartOfRent, r.EndOfRent)) >
                            averageMilliseconds)
                .ToList();
                
            return aboveAverageRentVehicles.GroupBy(v => new { v.VehicleModelId, Model = v.VehicleModel.Name, Brand = v.VehicleModel.Brand.Name})
                .Select(g => new RentDurationByModel
                {
                    VehicleModel = $"{g.Key.Brand} - {g.Key.Model}",
                    RentSpan = new TimeSpan((long)g.Average(v => v.Rents.Sum(r => (r.EndOfRent.Value.Ticks - r.StartOfRent.Ticks) / g.Count())))
                })
                .ToList();
        }

        private bool GetDoesVehicleAlreadyExist(VehicleType vehicleType, int vehicleBrandId, string model)
        {
            var doesVehicleModelAlreadyExist = DbContext.VehicleModels.Any(vm =>
                vm.BrandId == vehicleBrandId && vm.VehicleType == vehicleType &&
                vm.Name == model);

            return doesVehicleModelAlreadyExist;
        }
    }
}
