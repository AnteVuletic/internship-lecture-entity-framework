using System;
using Lecture.Domain.Enums;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Helpers;

namespace Lecture.Presentation.Actions.VehicleActions
{
    public class VehicleBrandDeleteAction : IAction
    {
        private readonly VehicleBrandRepository _vehicleBrandRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Delete vehicle brand";

        public VehicleBrandDeleteAction(VehicleBrandRepository vehicleBrandRepository)
        {
            _vehicleBrandRepository = vehicleBrandRepository;
        }

        public void Call()
        {
            var vehicleBrands = _vehicleBrandRepository.GetAll();
            PrintHelpers.PrintVehicleBrands(vehicleBrands);
            Console.WriteLine("Type in vehicle brand Id or exit");
            var isRead = ReadHelpers.TryReadNumber(out var vehicleBrandId);
            if (!isRead) 
                return;

            var result = _vehicleBrandRepository.Delete(vehicleBrandId);
            if (result == ResponseResultType.NotFound)
            {
                Console.WriteLine("Vehicle brand not found");
            }

            if (result == ResponseResultType.Success)
            {
                Console.WriteLine("Vehicle brand deleted successfully");
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
