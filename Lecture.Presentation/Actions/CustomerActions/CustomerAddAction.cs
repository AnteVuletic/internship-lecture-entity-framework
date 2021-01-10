using System;
using Lecture.Data.Entities.Models;
using Lecture.Domain.Constants;
using Lecture.Domain.Enums;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Helpers;

namespace Lecture.Presentation.Actions.CustomerActions
{
    public class CustomerAddAction : IAction
    {
        private readonly CustomerRepository _customerRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Add customer";

        public CustomerAddAction(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Call()
        {
            var customer = new Customer();

            Console.WriteLine("First name:");
            customer.FirstName = Console.ReadLine();

            Console.WriteLine("Last Name:");
            customer.LastName = Console.ReadLine();

            Console.WriteLine("Oib:");
            customer.Oib = Console.ReadLine();

            Console.WriteLine("Date of birth: (yyyy-MM-dd)");
            customer.DateOfBirth = DateTime.ParseExact(Console.ReadLine() ?? string.Empty, DateConstants.DateFormat, null);

            Console.WriteLine("Driving license number:");
            customer.DrivingLicenseIdentifier = Console.ReadLine();

            var responseResult = _customerRepository.Add(customer);

            if (responseResult == ResponseResultType.Success)
            {
                PrintHelpers.PrintCustomer(customer);
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"Failed to save customer, no changes applied.");
            Console.ReadLine();
        }

    }
}
