using System;
using Lecture.Domain.Constants;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Helpers;

namespace Lecture.Presentation.Actions.RentActions
{
    public class RentAddAction : IAction
    {
        private readonly RentRepository _rentRepository;
        private readonly VehicleRepository _vehicleRepository;
        private readonly RentRateRepository _rentRateRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly CustomerRepository _customerRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Rent add";

        public RentAddAction(
            RentRepository rentRepository,
            VehicleRepository vehicleRepository,
            RentRateRepository rentRateRepository,
            EmployeeRepository employeeRepository,
            CustomerRepository customerRepository
        ) {
            _rentRepository = rentRepository;
            _vehicleRepository = vehicleRepository;
            _rentRateRepository = rentRateRepository;
            _employeeRepository = employeeRepository;
            _customerRepository = customerRepository;
        }

        public void Call()
        {
            Console.WriteLine($"Enter start date {DateConstants.DateFormat}");
            var startDate = DateTime.ParseExact(Console.ReadLine(), DateConstants.DateFormat, null);

            Console.WriteLine($"Enter end date {DateConstants.DateFormat}");
            var endDate = DateTime.ParseExact(Console.ReadLine(), DateConstants.DateFormat, null);

            var vehicles = _vehicleRepository.GetAllAvailable();
            PrintHelpers.PrintVehicles(vehicles);
            Console.WriteLine("Type in vehicle id");
            var isVehicleIdRead = ReadHelpers.TryReadNumber(out var vehicleId);
            if (!isVehicleIdRead)
                return;

            var employees = _employeeRepository.GetAll();
            PrintHelpers.PrintEmployees(employees);
            Console.WriteLine("Type in employee id");
            var isEmployeeIdRead = ReadHelpers.TryReadNumber(out var employeeId);
            if (!isEmployeeIdRead)
                return;

            var customers = _customerRepository.GetAll();
            PrintHelpers.ShortPrintCustomers(customers);
            Console.WriteLine("Type in customer id");
            var isCustomerIdRead = ReadHelpers.TryReadNumber(out var customerId);
            if (!isCustomerIdRead)
                return;

            var rentRate = _rentRateRepository.GetNewestRentRates();
            var result = _rentRepository.Add(startDate, endDate, vehicleId, rentRate.Id, employeeId, customerId);

            Console.WriteLine(result.Message);
            Console.ReadLine();
            Console.Clear();
        }
    }
}
