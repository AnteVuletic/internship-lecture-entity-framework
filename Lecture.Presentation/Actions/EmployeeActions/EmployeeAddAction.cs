using System;
using Lecture.Data.Entities.Models;
using Lecture.Domain.Enums;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Helpers;

namespace Lecture.Presentation.Actions.EmployeeActions
{
    public class EmployeeAddAction : IAction
    {
        private readonly EmployeeRepository _employeeRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Add Employee";

        public EmployeeAddAction(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void Call()
        {
            var employee = new Employee();
            Console.WriteLine("First name:");
            employee.FirstName = Console.ReadLine();

            Console.WriteLine("Last Name:");
            employee.LastName = Console.ReadLine();

            var result = _employeeRepository.Add(employee);
            if (result == ResponseResultType.Success)
            {
                PrintHelpers.PrintEmployee(employee);
            }

            if (result == ResponseResultType.NoChanges)
            {
                Console.WriteLine("No changes have been applied");
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
