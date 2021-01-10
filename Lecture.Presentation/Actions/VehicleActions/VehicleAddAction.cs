using System;
using Lecture.Domain.Enums;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Helpers;

namespace Lecture.Presentation.Actions.VehicleActions
{
    public class VehicleAddAction : IAction
    {
        private readonly VehicleRepository _vehicleRepository;
        private readonly VehicleModelRepository _vehicleModelRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Vehicle add";

        public VehicleAddAction(VehicleRepository vehicleRepository, VehicleModelRepository vehicleModelRepository)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleModelRepository = vehicleModelRepository;
        }

        public void Call()
        {
            var vehicleModels = _vehicleModelRepository.GetAll();
            PrintHelpers.PrintVehicleModels(vehicleModels);
            Console.WriteLine("Vehicle model id or exit");
            var isRead = ReadHelpers.TryReadNumber(out var vehicleModelId);
            if (!isRead)
                return;

            Console.WriteLine("Enter kilometers");
            var isNumber = int.TryParse(Console.ReadLine(), out var kilometers);
            if (!isNumber)
            {
                Console.WriteLine("Kilometers not a number");
                Console.ReadLine();
                return;
            }

            var result = _vehicleRepository.Add(kilometers, vehicleModelId);

            if (result == ResponseResultType.NotFound)
            {
                Console.WriteLine("Vehicle model not found");
            }

            if (result == ResponseResultType.Success)
            {
                Console.WriteLine("Successfully added vehicle");
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
