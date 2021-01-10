using System;
using System.Linq;
using System.Threading;
using Lecture.Domain.Constants;
using Lecture.Domain.Enums;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Helpers;

namespace Lecture.Presentation.Actions.CustomerActions
{
    public class CustomerEditAction : IAction
    {
        private readonly CustomerRepository _customerRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Edit customer";

        public CustomerEditAction(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Call()
        {
            var customers = _customerRepository.GetAll();
            PrintHelpers.ShortPrintCustomers(customers);
            Console.WriteLine("\n Type customer Id or exit");
            var isRead = ReadHelpers.TryReadNumber(out var customerId);
            if (!isRead)
                return;

            var customer = customers.First(c => c.Id == customerId);
            
            Console.WriteLine("Press enter to skip edit");

            Console.WriteLine($"First Name: ({customer.FirstName})");
            customer.FirstName = ReadHelpers.TryReadLineIfNotEmpty(out var firstName)
                ? firstName
                : customer.FirstName;

            Console.WriteLine($"Last name: ({customer.LastName})");
            customer.LastName = ReadHelpers.TryReadLineIfNotEmpty(out var lastName)
                ? lastName
                : customer.LastName;

            Console.WriteLine($"Oib: ({customer.Oib})");
            customer.Oib = ReadHelpers.TryReadLineIfNotEmpty(out var oib)
                ? oib
                : customer.Oib;

            Console.WriteLine($"Driving License: ({customer.DrivingLicenseIdentifier})");
            customer.DrivingLicenseIdentifier = ReadHelpers.TryReadLineIfNotEmpty(out var drivingLicenseId)
                ? drivingLicenseId
                : customer.DrivingLicenseIdentifier;

            Console.WriteLine($"Date of birth: ({customer.DateOfBirth.ToShortDateString()})");
            customer.DateOfBirth = ReadHelpers.TryReadLineIfNotEmpty(out var dateOfBirthString) 
                ? DateTime.ParseExact(dateOfBirthString, DateConstants.DateFormat, null)
                : customer.DateOfBirth;

            var response = _customerRepository.Edit(customer, customerId);

            if (response == ResponseResultType.Success)
            {
                PrintHelpers.PrintCustomer(customer);
            }

            if (response == ResponseResultType.NotFound)
            {
                Console.WriteLine("Customer not found");
            }

            if (response == ResponseResultType.NoChanges)
            {
                Console.WriteLine("No changes applied");
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
