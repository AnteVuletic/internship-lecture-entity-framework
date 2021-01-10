using System;
using Lecture.Domain.Enums;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Helpers;

namespace Lecture.Presentation.Actions.RentActions
{
    public class RentRateDeleteAction : IAction
    {
        private readonly RentRateRepository _rentRateRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Delete rent rate";

        public RentRateDeleteAction(RentRateRepository rentRateRepository)
        {
            _rentRateRepository = rentRateRepository;
        }

        public void Call()
        {
            var rentRates = _rentRateRepository.GetAll();
            PrintHelpers.PrintRentRates(rentRates);
            Console.WriteLine("Enter rent rate id");
            var isRead = ReadHelpers.TryReadNumber(out var rentRateId);
            if (!isRead)
                return;

            var result = _rentRateRepository.Delete(rentRateId);
            if (result == ResponseResultType.NotFound)
            {
                Console.WriteLine("Rent rate not found");
            }

            if (result == ResponseResultType.Success)
            {
                Console.WriteLine("Successfully deleted rent rate");
            }

            if (result == ResponseResultType.NoChanges)
            {
                Console.WriteLine("No changes have been made");
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
