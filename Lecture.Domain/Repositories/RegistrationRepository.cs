using System;
using System.Collections.Generic;
using System.Linq;
using Lecture.Data.Entities;
using Lecture.Data.Entities.Models;
using Lecture.Domain.Enums;

namespace Lecture.Domain.Repositories
{
    public class RegistrationRepository : BaseRepository
    {
        public RegistrationRepository(RentACarDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(DateTime registrationDate, int vehicleId)
        {
            if (registrationDate > DateTime.Now)
            {
                return ResponseResultType.ValidationError;
            }

            var vehicle = DbContext.Vehicles.Find(vehicleId);
            if (vehicle == null)
            {
                return ResponseResultType.NotFound;
            }

            var registration = new Registration
            {
                Vehicle = vehicle,
                DateOfRegistration = registrationDate
            };
            DbContext.Registrations.Add(registration);

            return SaveChanges();
        }

        public ResponseResultType Delete(int registrationId)
        {
            var registration = DbContext.Registrations.Find(registrationId);
            if (registration == null)
            {
                return ResponseResultType.NotFound;
            }

            DbContext.Registrations.Remove(registration);
            return SaveChanges();
        }

        public ICollection<Registration> GetAll()
        {
            return DbContext.Registrations.ToList();
        }
    }
}
