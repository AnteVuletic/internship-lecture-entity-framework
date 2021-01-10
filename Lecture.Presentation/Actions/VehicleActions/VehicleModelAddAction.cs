using System;
using Lecture.Data.Enums;
using Lecture.Domain.Enums;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Helpers;

namespace Lecture.Presentation.Actions.VehicleActions
{
    public class VehicleModelAddAction : IAction
    {
        private readonly VehicleModelRepository _vehicleModelRepository;
        private readonly VehicleBrandRepository _vehicleBrandRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Vehicle model add";

        public VehicleModelAddAction(VehicleModelRepository vehicleModelRepository, VehicleBrandRepository vehicleBrandRepository)
        {
            _vehicleModelRepository = vehicleModelRepository;
            _vehicleBrandRepository = vehicleBrandRepository;
        }

        public void Call()
        {
            Console.WriteLine("Enter vehicle brand:");
            var vehicleBrands = _vehicleBrandRepository.GetAll();
            PrintHelpers.PrintVehicleBrands(vehicleBrands);
            Console.WriteLine("Enter vehicle brand id:");
            var isRead = ReadHelpers.TryReadNumber(out var vehicleBrandId);
            if (!isRead)
                return;

            Console.WriteLine("Enter one of vehicle types");
            var vehicleTypes = Enum.GetValues<VehicleType>();
            foreach (var vehicleType in vehicleTypes)
            {
                Console.WriteLine(vehicleType);
            }

            var isValidVehicleType = Enum.TryParse<VehicleType>(Console.ReadLine(), true, out var vehicleModelType);
            if (!isValidVehicleType)
            {
                Console.WriteLine("Invalid vehicle type");
                return;
            }

            Console.WriteLine("Enter vehicle model");
            var model = Console.ReadLine();

            var result = _vehicleModelRepository.Add(vehicleModelType, model, vehicleBrandId);

            if (result == ResponseResultType.AlreadyExists)
            {
                Console.WriteLine("Vehicle model already exists");
            }

            if (result == ResponseResultType.NotFound)
            {
                Console.WriteLine("Vehicle brand not found");
            }

            if (result == ResponseResultType.Success)
            {
                Console.WriteLine("Vehicle model successfully saved");
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
