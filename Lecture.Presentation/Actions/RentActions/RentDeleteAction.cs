using System;
using Lecture.Domain.Enums;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Helpers;

namespace Lecture.Presentation.Actions.RentActions
{
    public class RentDeleteAction : IAction
    {
        private readonly RentRepository _rentRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Rent delete";

        public RentDeleteAction(RentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }

        public void Call()
        {
            var rents = _rentRepository.GetAll();
            PrintHelpers.PrintRents(rents);
            Console.WriteLine("Type rent id or exit");
            var isRead = ReadHelpers.TryReadNumber(out var rentId);
            if (!isRead)
                return;

            var result = _rentRepository.Delete(rentId);
            if (result == ResponseResultType.NotFound)
            {
                Console.WriteLine("Rent not found");
            }

            if (result == ResponseResultType.Success)
            {
                Console.WriteLine("Rent successfully deleted");
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
