using System;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;

namespace Lecture.Presentation.Actions.Reports
{
    public class ReportVehicleTypesCountAction : IAction
    {
        private readonly VehicleRepository _vehicleRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Report count by vehicle type";

        public ReportVehicleTypesCountAction(VehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public void Call()
        {
            var vehicleTypeCount = _vehicleRepository.GetCountByVehicleTypes();
            foreach (var countByVehicleType in vehicleTypeCount)
            {
                Console.WriteLine($"Vehicle type: {countByVehicleType.VehicleType} Count: {countByVehicleType.Count}");
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
