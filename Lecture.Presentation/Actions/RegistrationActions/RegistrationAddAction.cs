using System;
using Lecture.Domain.Constants;
using Lecture.Domain.Enums;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Helpers;

namespace Lecture.Presentation.Actions.RegistrationActions
{
    public class RegistrationAddAction : IAction
    {
        private readonly RegistrationRepository _registrationRepository;
        private readonly VehicleRepository _vehicleRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Add vehicle registration";

        public RegistrationAddAction(RegistrationRepository registrationRepository, VehicleRepository vehicleRepository)
        {
            _registrationRepository = registrationRepository;
            _vehicleRepository = vehicleRepository;
        }
        
        public void Call()
        {
            var vehicles = _vehicleRepository.GetAllWithExpiredRegistration();
            PrintHelpers.PrintVehicles(vehicles);
            Console.WriteLine("Type vehicle id to register");
            var isRead = ReadHelpers.TryReadNumber(out var vehicleId);
            if (!isRead)
                return;

            Console.WriteLine("Enter vehicle registration date");
            var registrationDate = DateTime.ParseExact(Console.ReadLine(), DateConstants.DateFormat, null);

            var result = _registrationRepository.Add(registrationDate, vehicleId);

            if (result == ResponseResultType.ValidationError)
            {
                Console.WriteLine("Registration date cannot be in future");
            }

            if (result == ResponseResultType.NotFound)
            {
                Console.WriteLine("Vehicle not found");
            }

            if (result == ResponseResultType.Success)
            {
                Console.WriteLine("Vehicle registration successfully saved");
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
