using System.Configuration;
using Lecture.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lecture.Domain.Factories
{
    public static class DbContextFactory
    {
        public static RentACarDbContext GetRentACarDbContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlServer(ConfigurationManager.ConnectionStrings["RentACar"].ConnectionString).Options;
            return new RentACarDbContext(options);
        }
    }
}
