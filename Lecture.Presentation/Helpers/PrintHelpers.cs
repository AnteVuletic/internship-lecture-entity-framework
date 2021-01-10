using System;
using System.Collections.Generic;
using Lecture.Data.Entities.Models;

namespace Lecture.Presentation.Helpers
{
    public static class PrintHelpers
    {
        public static void ShortPrintCustomer(Customer customer)
        {
            Console.WriteLine($"Id: {customer.Id} \t First Name: {customer.FirstName} \t Last Name: {customer.LastName} \t OIB: {customer.Oib}");
        }

        public static void ShortPrintCustomers(ICollection<Customer> customers)
        {
            foreach (var customer in customers)
            {
                ShortPrintCustomer(customer);
            }
        }

        public static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"Id: {customer.Id} \n" +
                              $"First Name: {customer.FirstName} \n" +
                              $"Last Name: {customer.LastName} \n" +
                              $"OIB: {customer.Oib} \n" +
                              $"Date Of birth: {customer.DateOfBirth.ToShortDateString()} \n" +
                              $"Driving license identifier: {customer.DrivingLicenseIdentifier}");
        }

        public static void PrintEmployee(Employee employee)
        {
            Console.WriteLine($"Id: {employee.Id} \n" +
                              $"First Name: {employee.FirstName} \n" +
                              $"Last Name: {employee.LastName}");
        }

        public static void PrintEmployees(ICollection<Employee> employees)
        {
            foreach (var employee in employees)
            {
                PrintEmployee(employee);
            }
        }

        public static void PrintVehicleBrand(VehicleBrand vehicleBrand)
        {
            Console.WriteLine($"Id: {vehicleBrand.Id} \t Brand: {vehicleBrand.Brand}");
        }

        public static void PrintVehicleBrands(ICollection<VehicleBrand> vehicleBrands)
        {
            foreach (var vehicleBrand in vehicleBrands)
            {
                PrintVehicleBrand(vehicleBrand);
            }
        }

        public static void PrintVehicleModel(VehicleModel vehicleModel)
        {
            Console.WriteLine($"Id: {vehicleModel.Id} \t Type: {vehicleModel.VehicleType} \t Brand: {vehicleModel.Brand.Brand} \t Model Name: {vehicleModel.Model}");
        }

        public static void PrintVehicleModels(ICollection<VehicleModel> vehicleModels)
        {
            foreach (var vehicleModel in vehicleModels)
            {
                PrintVehicleModel(vehicleModel);
            }
        }

        public static void PrintVehicle(Vehicle vehicle)
        {
            Console.WriteLine($"Id: {vehicle.Id} \t Brand: {vehicle.VehicleModel.Brand.Brand} \tModel: {vehicle.VehicleModel.Model} \t Kilometers: {vehicle.Kilometers}");
        }

        public static void PrintVehicles(ICollection<Vehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                PrintVehicle(vehicle);
            }
        }

        public static void PrintRentRate(RentRate rentRate)
        {
            Console.WriteLine($"Id: {rentRate.Id} \t Cost: {rentRate.Cost} \t Created at: {rentRate.CreatedAt.ToShortDateString()} \t Rent type: {rentRate.RentRateType}");
        }

        public static void PrintRentRates(ICollection<RentRate> rentRates)
        {
            foreach (var rentRate in rentRates)
            {
                PrintRentRate(rentRate);
            }
        }

        public static void PrintRent(Rent rent)
        {
            Console.WriteLine($"Id: {rent.Id} \t Vehicle: {rent.Vehicle.VehicleModel.Brand.Brand} - {rent.Vehicle.VehicleModel.Model} - {rent.Vehicle.Kilometers} \t Start date: {rent.StartOfRent} \t End date: {rent.EndOfRent}");
        }

        public static void PrintRents(ICollection<Rent> rents)
        {
            foreach (var rent in rents)
            {
                PrintRent(rent);
            }
        }

        public static void PrintRegistration(Registration registration)
        {
            Console.WriteLine($"Id: {registration.Id} \t Registration start: {registration.DateOfRegistration} \t Registration End {registration.DateOfRegistration.AddYears(1)}");
        }

        public static void PrintRegistrations(ICollection<Registration> registrations)
        {
            foreach (var registration in registrations)
            {
                PrintRegistration(registration);
            }
        }
    }
}
