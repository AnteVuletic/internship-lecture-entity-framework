using System;
using System.Collections.Generic;
using Lecture.Data.Entities.Models;
using Lecture.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace Lecture.Data.Seeds
{
    public static class DataBaseSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Employee>()
                .HasData(new List<Employee>
                {
                    new Employee
                    {
                        Id = 1,
                        FirstName = "Mate",
                        LastName = "Matić"
                    },
                    new Employee
                    {
                        Id = 2,
                        FirstName = "Jure",
                        LastName = "Jurić"
                    },
                    new Employee
                    {
                        Id = 3,
                        FirstName = "Šime",
                        LastName = "Šimić"
                    }
                });

            builder.Entity<Customer>()
                .HasData(new List<Customer>
                {
                    new Customer
                    {
                        Id = 1,
                        DateOfBirth = new DateTime(1995, 10, 1),
                        DrivingLicenseIdentifier = "12831121",
                        FirstName = "Ante",
                        LastName = "Antić",
                        Oib = "12382172389"
                    },
                    new Customer
                    {
                        Id = 2,
                        DateOfBirth = new DateTime(1998, 10, 1),
                        DrivingLicenseIdentifier = "12831122",
                        FirstName = "Matija",
                        LastName = "Luketin",
                        Oib = "12382172159"
                    },
                    new Customer
                    {
                        Id = 3,
                        DateOfBirth = new DateTime(1993, 10, 1),
                        DrivingLicenseIdentifier = "12831123",
                        FirstName = "Krešimir",
                        LastName = "Čondić",
                        Oib = "12382172129"
                    },
                    new Customer
                    {
                        Id = 4,
                        DateOfBirth = new DateTime(1996, 10, 1),
                        DrivingLicenseIdentifier = "12831124",
                        FirstName = "Roko",
                        LastName = "Radanović",
                        Oib = "12382172139"
                    },
                });

            builder.Entity<VehicleBrand>()
                .HasData(new List<VehicleBrand>
                {
                    new VehicleBrand
                    {
                        Id = 1,
                        Brand = "Volkswagen"
                    },
                    new VehicleBrand
                    {
                        Id = 2,
                        Brand = "Porsche"
                    },
                    new VehicleBrand
                    {
                        Id = 3,
                        Brand = "Yamaha"
                    },
                    new VehicleBrand
                    {
                        Id = 4,
                        Brand = "Citroen"
                    }
                });

            builder.Entity<VehicleModel>()
                .HasData(new List<VehicleModel>
                {
                    new VehicleModel
                    {
                        Id = 1,
                        BrandId = 1,
                        Model = "Up",
                        VehicleType = VehicleType.Car
                    },
                    new VehicleModel
                    {
                        Id = 2,
                        BrandId = 1,
                        Model = "Golf",
                        VehicleType = VehicleType.Car
                    },
                    new VehicleModel
                    {
                        Id = 3,
                        BrandId = 2,
                        Model = "Cayenne",
                        VehicleType = VehicleType.Car
                    },
                    new VehicleModel
                    {
                        Id = 4,
                        BrandId = 3,
                        Model = "T-Max",
                        VehicleType = VehicleType.Motorcycle
                    },
                    new VehicleModel
                    {
                        Id = 5,
                        BrandId = 4,
                        Model = "Berlingo",
                        VehicleType = VehicleType.Van
                    }
                });

            builder.Entity<Vehicle>()
                .HasData(new List<Vehicle>
                {
                    new Vehicle
                    {
                        Id = 1,
                        Kilometers = 0,
                        VehicleModelId = 1
                    },
                    new Vehicle
                    {
                        Id = 2,
                        Kilometers = 0,
                        VehicleModelId = 1
                    },
                    new Vehicle
                    {
                        Id = 3,
                        Kilometers = 20,
                        VehicleModelId = 2
                    },
                    new Vehicle
                    {
                        Id = 4,
                        Kilometers = 205,
                        VehicleModelId = 2
                    },

                    new Vehicle
                    {
                        Id = 5,
                        Kilometers = 265,
                        VehicleModelId = 2
                    },
                    new Vehicle
                    {
                        Id = 6,
                        Kilometers = 205,
                        VehicleModelId = 3
                    },
                    new Vehicle
                    {
                        Id = 7,
                        Kilometers = 205,
                        VehicleModelId = 4
                    },
                    new Vehicle
                    {
                        Id = 8,
                        Kilometers = 205,
                        VehicleModelId = 5
                    }
                });

            builder.Entity<Registration>()
                .HasData(new List<Registration>
                {
                    new Registration
                    {
                        Id = 1,
                        DateOfRegistration = new DateTime(2020, 1, 1),
                        VehicleId = 1
                    },
                    new Registration
                    {
                        Id = 2,
                        DateOfRegistration = new DateTime(2020, 2, 1),
                        VehicleId = 2
                    },
                    new Registration
                    {
                        Id = 3,
                        DateOfRegistration = new DateTime(2020, 3, 1),
                        VehicleId = 3
                    },
                    new Registration
                    {
                        Id = 4,
                        DateOfRegistration = new DateTime(2020, 4, 1),
                        VehicleId = 4
                    },
                    new Registration
                    {
                        Id = 5,
                        DateOfRegistration = new DateTime(2020, 5, 1),
                        VehicleId = 5
                    },
                    new Registration
                    {
                        Id = 6,
                        DateOfRegistration = new DateTime(2020, 6, 1),
                        VehicleId = 6
                    },
                    new Registration
                    {
                        Id = 7,
                        DateOfRegistration = new DateTime(2020, 7, 1),
                        VehicleId = 7
                    },
                    new Registration
                    {
                        Id = 8,
                        DateOfRegistration = new DateTime(2020, 8, 1),
                        VehicleId = 8
                    }
                });

            builder.Entity<RentRate>()
                .HasData(new List<RentRate>
                {
                    new RentRate
                    {
                        Id = 1,
                        Cost = 200m,
                        CreatedAt = DateTime.Now,
                        RentRateType = RentRateType.Winter
                    },
                    new RentRate
                    {
                        Id = 2,
                        Cost = 300m,
                        CreatedAt = DateTime.Now,
                        RentRateType = RentRateType.Summer
                    }
                });

            builder.Entity<Rent>()
                .HasData(new List<Rent>
                {
                    new Rent
                    {
                        Id = 1,
                        CustomerId = 1,
                        EmployeeId = 1,
                        StartOfRent = new DateTime(2020, 1, 1),
                        EndOfRent = new DateTime(2020, 1, 2),
                        VehicleId = 1,
                        RentRateId = 1
                    },
                    new Rent
                    {
                        Id = 2,
                        CustomerId = 1,
                        EmployeeId = 1,
                        StartOfRent = new DateTime(2020, 2, 1),
                        EndOfRent = new DateTime(2020, 2, 2),
                        VehicleId = 2,
                        RentRateId = 1
                    },
                    new Rent
                    {
                        Id = 3,
                        CustomerId = 1,
                        EmployeeId = 2,
                        StartOfRent = new DateTime(2020, 3, 1),
                        EndOfRent = new DateTime(2020, 3, 5),
                        VehicleId = 1,
                        RentRateId = 2
                    },
                    new Rent
                    {
                        Id = 4,
                        CustomerId = 2,
                        EmployeeId = 1,
                        StartOfRent = new DateTime(2020, 4, 1),
                        EndOfRent = new DateTime(2020, 4, 2),
                        VehicleId = 3,
                        RentRateId = 2
                    },
                    new Rent
                    {
                        Id = 5,
                        CustomerId = 2,
                        EmployeeId = 3,
                        StartOfRent = new DateTime(2020, 4, 5),
                        EndOfRent = new DateTime(2020, 4, 6),
                        VehicleId = 5,
                        RentRateId = 2
                    },
                    new Rent
                    {
                        Id = 6,
                        CustomerId = 2,
                        EmployeeId = 3,
                        StartOfRent = new DateTime(2020, 5, 1),
                        EndOfRent = new DateTime(2020, 5, 2),
                        VehicleId = 6,
                        RentRateId = 2
                    },
                    new Rent
                    {
                        Id = 7,
                        CustomerId = 3,
                        EmployeeId = 1,
                        StartOfRent = new DateTime(2020, 6, 1),
                        EndOfRent = new DateTime(2020, 6, 2),
                        VehicleId = 7,
                        RentRateId = 2
                    },
                    new Rent
                    {
                        Id = 8,
                        CustomerId = 3,
                        EmployeeId = 2,
                        StartOfRent = new DateTime(2020, 7, 1),
                        EndOfRent = new DateTime(2020, 7, 6),
                        VehicleId = 8,
                        RentRateId = 2
                    },
                    new Rent
                    {
                        Id = 9,
                        CustomerId = 3,
                        EmployeeId = 3,
                        StartOfRent = new DateTime(2020, 8, 1),
                        EndOfRent = new DateTime(2020, 8, 2),
                        VehicleId = 1,
                        RentRateId = 2
                    },
                    new Rent
                    {
                        Id = 10,
                        CustomerId = 4,
                        EmployeeId = 1,
                        StartOfRent = new DateTime(2020, 9, 1),
                        EndOfRent = new DateTime(2020, 9, 2),
                        VehicleId = 2,
                        RentRateId = 2
                    },
                    new Rent
                    {
                        Id = 11,
                        CustomerId = 4,
                        EmployeeId = 2,
                        StartOfRent = new DateTime(2020, 10, 1),
                        EndOfRent = new DateTime(2020, 10, 2),
                        VehicleId = 3,
                        RentRateId = 1
                    },
                    new Rent
                    {
                        Id = 12,
                        CustomerId = 4,
                        EmployeeId = 1,
                        StartOfRent = new DateTime(2020, 11, 1),
                        EndOfRent = new DateTime(2020, 11, 2),
                        VehicleId = 4,
                        RentRateId = 1
                    },
                    new Rent
                    {
                        Id = 13,
                        CustomerId = 4,
                        EmployeeId = 2,
                        StartOfRent = new DateTime(2020, 12, 1),
                        EndOfRent = new DateTime(2020, 12, 2),
                        VehicleId = 5,
                        RentRateId = 1
                    },
                    new Rent
                    {
                        Id = 14,
                        CustomerId = 2,
                        EmployeeId = 2,
                        StartOfRent = new DateTime(2020, 5, 1),
                        EndOfRent = new DateTime(2020, 5, 2),
                        VehicleId = 6,
                        RentRateId = 2
                    },
                    new Rent
                    {
                        Id = 15,
                        CustomerId = 3,
                        EmployeeId = 3,
                        StartOfRent = new DateTime(2020, 6, 1),
                        EndOfRent = new DateTime(2020, 6, 2),
                        VehicleId = 7,
                        RentRateId = 2
                    },
                    new Rent
                    {
                        Id = 16,
                        CustomerId = 2,
                        EmployeeId = 2,
                        StartOfRent = new DateTime(2020, 7, 1),
                        EndOfRent = new DateTime(2020, 7, 2),
                        VehicleId = 8,
                        RentRateId = 2
                    },
                    new Rent
                    {
                        Id = 17,
                        CustomerId = 1,
                        EmployeeId = 1,
                        StartOfRent = new DateTime(2020, 1, 5),
                        EndOfRent = new DateTime(2020, 1, 6),
                        VehicleId = 1,
                        RentRateId = 1
                    },
                    new Rent
                    {
                        Id = 18,
                        CustomerId = 2,
                        EmployeeId = 3,
                        StartOfRent = new DateTime(2020, 2, 5),
                        EndOfRent = new DateTime(2020, 2, 8),
                        VehicleId = 2,
                        RentRateId = 1
                    },
                    new Rent
                    {
                        Id = 19,
                        CustomerId = 3,
                        EmployeeId = 2,
                        StartOfRent = new DateTime(2020, 6, 3),
                        EndOfRent = new DateTime(2020, 6, 6),
                        VehicleId = 3,
                        RentRateId = 2
                    },
                    new Rent
                    {
                        Id = 20,
                        CustomerId = 4,
                        EmployeeId = 1,
                        StartOfRent = new DateTime(2020, 11, 10),
                        EndOfRent = new DateTime(2020, 11, 20),
                        VehicleId = 4,
                        RentRateId = 1
                    }
                });
        }
    }
}
