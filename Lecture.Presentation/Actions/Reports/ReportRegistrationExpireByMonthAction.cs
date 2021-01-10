using System;
using System.Threading;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Helpers;

namespace Lecture.Presentation.Actions.Reports
{
    public class ReportRegistrationExpireByMonthAction : IAction
    {
        private readonly VehicleRepository _vehicleRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Registration expires by month";

        public ReportRegistrationExpireByMonthAction(VehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public void Call()
        {
            Console.WriteLine("Please write number of months to expire");
            var isNumber = ReadHelpers.TryReadNumber(out var numberOfMonths);
            if (!isNumber)
                return;

            var vehicles = _vehicleRepository.GetAllExpiringByMonth(numberOfMonths);
            PrintHelpers.PrintVehicles(vehicles);

            Console.ReadLine();
            Console.Clear();
        }
    }
}
