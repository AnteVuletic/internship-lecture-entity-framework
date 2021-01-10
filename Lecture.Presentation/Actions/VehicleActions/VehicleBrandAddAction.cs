using System;
using Lecture.Domain.Enums;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;

namespace Lecture.Presentation.Actions.VehicleActions
{
    public class VehicleBrandAddAction : IAction
    {
        private readonly VehicleBrandRepository _vehicleBrandRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Add vehicle brand";

        public VehicleBrandAddAction(VehicleBrandRepository vehicleBrandRepository)
        {
            _vehicleBrandRepository = vehicleBrandRepository;
        }

        public void Call()
        {
            Console.WriteLine("Type brand name:");
            var brand = Console.ReadLine();
            var result = _vehicleBrandRepository.Add(brand);

            if (result == ResponseResultType.AlreadyExists)
            {
                Console.WriteLine("Vehicle brand already exists");
            }

            if (result == ResponseResultType.Success)
            {
                Console.WriteLine($"Added brand: {brand}");
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
