using System;
using Lecture.Data.Enums;
using Lecture.Domain.Enums;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;

namespace Lecture.Presentation.Actions.RentActions
{
    public class RentRateAddAction : IAction
    {
        private readonly RentRateRepository _rentRateRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Add rent rate";

        public RentRateAddAction(RentRateRepository rentRateRepository)
        {
            _rentRateRepository = rentRateRepository;
        }

        public void Call()
        {
            Console.WriteLine("Enter one of rate type");
            var rentTypes = Enum.GetValues<RentRateType>();
            foreach (var rentType in rentTypes)
            {
                Console.WriteLine(rentType);
            }
            var isRentRateType = Enum.TryParse<RentRateType>(Console.ReadLine(), true, out var rentRateType);
            if (!isRentRateType)
            {
                Console.WriteLine("Error not valid rent rate type");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Enter rate cost per half day");
            var isDecimal = decimal.TryParse(Console.ReadLine(), out var cost);
            if (!isDecimal)
            {
                Console.WriteLine("Error not decimal value");
                Console.ReadLine();
                return;
            }

            var result = _rentRateRepository.Add(rentRateType, cost);

            if (result == ResponseResultType.ValidationError)
            {
                Console.WriteLine("Cost cannot be negative");
            }

            if (result == ResponseResultType.Success)
            {
                Console.WriteLine("Successfully added rent rate");
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
