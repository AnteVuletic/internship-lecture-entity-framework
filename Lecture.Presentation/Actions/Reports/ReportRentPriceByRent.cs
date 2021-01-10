using System;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Helpers;

namespace Lecture.Presentation.Actions.Reports
{
    public class ReportRentPriceByRent : IAction
    {
        private readonly RentRepository _rentRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Report Rent price by rent";

        public ReportRentPriceByRent(RentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }

        public void Call()
        {
            var rents = _rentRepository.GetAll();
            PrintHelpers.PrintRents(rents);
            Console.WriteLine("Enter id for rent");
            var isRead = ReadHelpers.TryReadNumber(out var rentId);
            if (!isRead)
                return;

            var rentCost = _rentRepository.GetRentCost(rentId);
            Console.WriteLine($"Id: {rentCost.Id} \n " +
                              $"Start of rent: {rentCost.StartOfRent} \n " +
                              $"End of rent: {rentCost.EndOfRent} \n " +
                              $"Cost: {rentCost.Cost}kn \n " +
                              $"Vehicle: {rentCost.Vehicle} \n" +
                              $"{rentCost.Rate}");

            Console.ReadLine();
            Console.Clear();
        }
    }
}
