using System;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;

namespace Lecture.Presentation.Actions.Reports
{
    public class ReportBrandCount : IAction
    {
        private readonly VehicleRepository _vehicleRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Count vehicles by brand";

        public ReportBrandCount(VehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public void Call()
        {
            var brandCounts = _vehicleRepository.GetCountByBrands();
            foreach (var countByBrand in brandCounts)
            {
                Console.WriteLine($"Name: {countByBrand.Brand} Count: {countByBrand.Count}");
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
