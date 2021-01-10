using System;
using Lecture.Domain.Enums;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Helpers;

namespace Lecture.Presentation.Actions.RegistrationActions
{
    public class RegistrationDeleteAction : IAction
    {
        private readonly RegistrationRepository _registrationRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Registration delete";

        public RegistrationDeleteAction(RegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public void Call()
        {
            var registrations = _registrationRepository.GetAll();
            PrintHelpers.PrintRegistrations(registrations);
            Console.WriteLine("Type registration id or exit");
            var isRead = ReadHelpers.TryReadNumber(out var registrationId);
            if (!isRead)
                return;

            var result = _registrationRepository.Delete(registrationId);
            if (result == ResponseResultType.NotFound)
            {
                Console.WriteLine("Registration not found");
            }

            if (result == ResponseResultType.Success)
            {
                Console.WriteLine("Successfully deleted registration");
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
