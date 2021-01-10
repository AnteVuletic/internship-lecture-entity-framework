using System;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Helpers;

namespace Lecture.Presentation.Actions.Reports
{
    public class ReportNumberOfRentsForMonthByYear : IAction
    {
        private readonly RentRepository _rentRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Number of rents per month for year";

        public ReportNumberOfRentsForMonthByYear(RentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }

        public void Call()
        {
            Console.WriteLine("Please enter year:");
            var isNumber = ReadHelpers.TryReadNumber(out var year);
            if (!isNumber)
                return;

            var rents = _rentRepository.GetCountRentsByMonthByYear(year);
            foreach (var countRentsByDate in rents)
            {
                Console.WriteLine($"Date: {countRentsByDate.Date.Month}/{countRentsByDate.Date.Year} Count: {countRentsByDate.Count}");
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
