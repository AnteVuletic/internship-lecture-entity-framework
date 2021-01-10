using System;
using Lecture.Domain.Enums;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Helpers;

namespace Lecture.Presentation.Actions.VehicleActions
{
    public class VehicleModelDeleteAction : IAction
    {
        private readonly VehicleModelRepository _vehicleModelRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Vehicle model delete action";

        public VehicleModelDeleteAction(VehicleModelRepository vehicleModelRepository)
        {
            _vehicleModelRepository = vehicleModelRepository;
        }

        public void Call()
        {
            var vehicleModels = _vehicleModelRepository.GetAll();
            PrintHelpers.PrintVehicleModels(vehicleModels);
            Console.WriteLine("Type in vehicle model Id or exit");
            var isRead = ReadHelpers.TryReadNumber(out var vehicleModelId);
            if (!isRead)
                return;

            var result = _vehicleModelRepository.Delete(vehicleModelId);
            if (result == ResponseResultType.NotFound)
            {
                Console.WriteLine("Vehicle model not found");
            }

            if (result == ResponseResultType.Success)
            {
                Console.WriteLine("Vehicle model deleted successfully");
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
