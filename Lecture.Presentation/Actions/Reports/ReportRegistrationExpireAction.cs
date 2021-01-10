using System;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Helpers;

namespace Lecture.Presentation.Actions.Reports
{
    public class ReportRegistrationExpireAction : IAction
    {
        private readonly VehicleRepository _vehicleRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Registration expired";

        public ReportRegistrationExpireAction(VehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public void Call()
        {
            var vehicles = _vehicleRepository.GetAllWithExpiredRegistration();
            PrintHelpers.PrintVehicles(vehicles);

            Console.ReadLine();
            Console.Clear();
        }
    }
}
