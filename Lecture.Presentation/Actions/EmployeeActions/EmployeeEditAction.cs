using System;
using System.Linq;
using Lecture.Domain.Enums;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Helpers;

namespace Lecture.Presentation.Actions.EmployeeActions
{
    public class EmployeeEditAction : IAction
    {
        private readonly EmployeeRepository _employeeRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Employee edit";

        public EmployeeEditAction(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void Call()
        {
            var employees = _employeeRepository.GetAll();
            PrintHelpers.PrintEmployees(employees);
            var isRead = ReadHelpers.TryReadNumber(out var employeeId);
            if (!isRead)
                return;

            var employee = employees.First(e => e.Id == employeeId);

            Console.WriteLine("Press enter to skip edit");

            Console.WriteLine($"First Name: ({employee.FirstName})");
            employee.FirstName = ReadHelpers.TryReadLineIfNotEmpty(out var firstName)
                ? firstName
                : employee.FirstName;

            Console.WriteLine($"Last name: ({employee.LastName})");
            employee.LastName = ReadHelpers.TryReadLineIfNotEmpty(out var lastName)
                ? lastName
                : employee.LastName;

            var result = _employeeRepository.Edit(employee, employeeId);

            if (result == ResponseResultType.NotFound)
            {
                Console.WriteLine("Employee not found");
            }

            if (result == ResponseResultType.Success)
            {
                PrintHelpers.PrintEmployee(employee);
            }

            if (result == ResponseResultType.NoChanges)
            {
                Console.WriteLine("No changes applied");
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
