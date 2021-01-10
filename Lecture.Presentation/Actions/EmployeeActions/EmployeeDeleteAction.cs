using System;
using Lecture.Domain.Enums;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Helpers;

namespace Lecture.Presentation.Actions.EmployeeActions
{
    public class EmployeeDeleteAction : IAction
    {
        private readonly EmployeeRepository _employeeRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Employee delete";

        public EmployeeDeleteAction(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void Call()
        {
            var employees = _employeeRepository.GetAll();
            PrintHelpers.PrintEmployees(employees);
            Console.WriteLine("Type in Employee Id or exit");
            var isRead = ReadHelpers.TryReadNumber(out var employeeId);
            if (!isRead)
                return;

            var result = _employeeRepository.Delete(employeeId);
            if (result == ResponseResultType.NotFound)
            {
                Console.WriteLine("Employee not found");
            }

            if (result == ResponseResultType.Success)
            {
                Console.WriteLine("Employee successfully added");
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
