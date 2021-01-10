using System;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;

namespace Lecture.Presentation.Actions.Reports
{
    public class ReportAboveAverageRentsForVehicleModels : IAction
    {
        private readonly VehicleModelRepository _vehicleModelRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Above average vehicle models";

        public ReportAboveAverageRentsForVehicleModels(VehicleModelRepository vehicleModelRepository)
        {
            _vehicleModelRepository = vehicleModelRepository;
        }

        public void Call()
        {
            var rentDurationByModel = _vehicleModelRepository.GetCountByModelBiggerThenAverage();
            foreach (var rentDuration in rentDurationByModel)
            {
                Console.WriteLine($"Name: {rentDuration.VehicleModel} Rent duration in days: {rentDuration.RentSpan.TotalDays}");
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
