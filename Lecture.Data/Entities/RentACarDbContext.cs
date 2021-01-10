using System.IO;
using System.Linq;
using Lecture.Data.Entities.Models;
using Lecture.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Lecture.Data.Entities
{
    public class RentACarDbContext : DbContext
    {
        public RentACarDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<RentRate> RentRates { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleBrand> VehicleBrands { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataBaseSeed.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }

    public class RentACarContextFactory : IDesignTimeDbContextFactory<RentACarDbContext>
    {
        public RentACarDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddXmlFile("App.config")
                .Build();
            configuration
                .Providers
                .First()
                .TryGet("connectionStrings:add:RentACar:connectionString", out var connectionString);

            var options = new DbContextOptionsBuilder<RentACarDbContext>().UseSqlServer(connectionString).Options;
            return new RentACarDbContext(options);
        }
    }
}
