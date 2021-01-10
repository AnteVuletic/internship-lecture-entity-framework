using System.Collections.Generic;
using System.Linq;
using Lecture.Data.Entities;
using Lecture.Data.Entities.Models;
using Lecture.Domain.Enums;
using Lecture.Domain.Models;

namespace Lecture.Domain.Repositories
{
    public class VehicleBrandRepository : BaseRepository
    {
        public VehicleBrandRepository(RentACarDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(string brand)
        {
            var isBrandAlreadyAdded = DbContext.VehicleBrands.Any(vb => vb.Brand.Contains(brand));
            if (isBrandAlreadyAdded)
            {
                return ResponseResultType.AlreadyExists;
            }

            var vehicleBrand = new VehicleBrand
            {
                Brand = brand
            };

            DbContext.VehicleBrands.Add(vehicleBrand);
            return SaveChanges();
        }

        public ResponseResultType Delete(int vehicleBrandId)
        {
            var vehicleBrand = DbContext.VehicleBrands.Find(vehicleBrandId);
            if (vehicleBrand == null)
            {
                return ResponseResultType.NotFound;
            }

            DbContext.VehicleBrands.Remove(vehicleBrand);
            return SaveChanges();
        }

        public ICollection<VehicleBrand> GetAll()
        {
            return DbContext.VehicleBrands.ToList();
        }
    }
}
