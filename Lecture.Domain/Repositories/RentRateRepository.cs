using System;
using System.Collections.Generic;
using System.Linq;
using Lecture.Data.Entities;
using Lecture.Data.Entities.Models;
using Lecture.Data.Enums;
using Lecture.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Lecture.Domain.Repositories
{
    public class RentRateRepository : BaseRepository
    {
        public RentRateRepository(RentACarDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(RentRateType rateType, decimal cost)
        {
            if (cost < 0)
            {
                return ResponseResultType.ValidationError;
            }

            var rentRate = new RentRate
            {
                Cost =  cost,
                RentRateType = rateType,
                CreatedAt = DateTime.Now
            };

            DbContext.RentRates.Add(rentRate);
            return SaveChanges();
        }

        public ResponseResultType Delete(int rentRateId)
        {
            var rentRate = DbContext.RentRates.Find(rentRateId);
            if (rentRate == null)
            {
                return ResponseResultType.NotFound;
            }

            DbContext.RentRates.Remove(rentRate);
            return SaveChanges();
        }

        public ICollection<RentRate> GetAll()
        {
            return DbContext.RentRates
                .ToList();
        }

        public RentRate GetNewestRentRates()
        {
            var rentRateType = DateTime.Now.Month > 3 && DateTime.Now.Month < 10
                ? RentRateType.Summer
                : RentRateType.Winter;

            var rentRate = DbContext.RentRates
                .Where(rr => rr.RentRateType == rentRateType)
                .OrderByDescending(rr => rr.CreatedAt)
                .First();

            return rentRate;
        }
    }
}
