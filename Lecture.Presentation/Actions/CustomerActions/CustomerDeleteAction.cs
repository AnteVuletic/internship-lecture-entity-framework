using System;
using Lecture.Domain.Enums;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Helpers;

namespace Lecture.Presentation.Actions.CustomerActions
{
    public class CustomerDeleteAction : IAction
    {
        private readonly CustomerRepository _customerRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Customer delete";

        public CustomerDeleteAction(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public void Call()
        {
            var customers = _customerRepository.GetAll();
            PrintHelpers.ShortPrintCustomers(customers);
            Console.WriteLine("Type in customer Id or exit");
            var isRead = ReadHelpers.TryReadNumber(out var customerId);
            if (!isRead) return;

            var response = _customerRepository.Delete(customerId);

            if (response == ResponseResultType.Success)
            {
                Console.WriteLine("Customer successfully deleted");
            }

            if (response == ResponseResultType.NoChanges)
            {
                Console.WriteLine("No changes applied");
            }

            if (response == ResponseResultType.NotFound)
            {
                Console.WriteLine("Customer does not exist");
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
