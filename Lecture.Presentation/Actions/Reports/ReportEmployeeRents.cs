using System;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Helpers;

namespace Lecture.Presentation.Actions.Reports
{
    public class ReportEmployeeRents : IAction
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly RentRepository _rentRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Employee last number of rents";

        public ReportEmployeeRents(EmployeeRepository employeeRepository, RentRepository rentRepository)
        {
            _employeeRepository = employeeRepository;
            _rentRepository = rentRepository;
        }

        public void Call()
        {
            var employees = _employeeRepository.GetAll();
            PrintHelpers.PrintEmployees(employees);
            Console.WriteLine("Enter employee id or exit");
            var isRead = ReadHelpers.TryReadNumber(out var employeeId);
            if (!isRead)
                return;

            Console.WriteLine("Number of last rents");
            isRead = ReadHelpers.TryReadNumber(out var numberOfMonths);
            if (!isRead)
                return;

            var rents = _rentRepository.GetByEmployee(numberOfMonths, employeeId);
            PrintHelpers.PrintRents(rents);

            Console.ReadLine();
            Console.Clear();
        }
    }
}
