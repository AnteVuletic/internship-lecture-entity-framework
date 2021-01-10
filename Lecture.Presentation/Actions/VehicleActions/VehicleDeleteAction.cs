using System;
using Lecture.Domain.Enums;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Helpers;

namespace Lecture.Presentation.Actions.VehicleActions
{
    public class VehicleDeleteAction : IAction
    {
        private readonly VehicleRepository _vehicleRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Vehicle delete";

        public VehicleDeleteAction(VehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public void Call()
        {
            var vehicles = _vehicleRepository.GetAll();
            PrintHelpers.PrintVehicles(vehicles);
            var isRead = ReadHelpers.TryReadNumber(out var vehicleId);
            if (!isRead)
                return;

            var result = _vehicleRepository.Delete(vehicleId);

            if (result == ResponseResultType.NotFound)
            {
                Console.WriteLine("Vehicle not found");
            }

            if (result == ResponseResultType.Success)
            {
                Console.WriteLine("Vehicle successfully removed");
            }

            if (result == ResponseResultType.NoChanges)
            {
                Console.WriteLine("No changes made");
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
