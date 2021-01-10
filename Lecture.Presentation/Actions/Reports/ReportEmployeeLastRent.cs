using System;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;

namespace Lecture.Presentation.Actions.Reports
{
    public class ReportEmployeeLastRent : IAction
    {
        private readonly EmployeeRepository _employeeRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Employee last rents";

        public ReportEmployeeLastRent(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void Call()
        {
            var employeeLastRents = _employeeRepository.GetEmployeeLastRents();

            foreach (var employeeLastRent in employeeLastRents)
            {
                Console.WriteLine($"Id {employeeLastRent.Id} \t Full Name: {employeeLastRent.FullName} \t Last Rent: {employeeLastRent.LastRent.ToShortDateString()}");    
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
