using System.Collections.Generic;
using Lecture.Domain.Factories;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Actions;
using Lecture.Presentation.Actions.Reports;

namespace Lecture.Presentation.Factories
{
    public static class ReportActionsFactory
    {
        public static ReportsParentAction GetReportsParentAction()
        {
            var actions = new List<IAction>
            {
                new ReportRegistrationExpireAction(RepositoryFactory.GetRepository<VehicleRepository>()),
                new ReportRegistrationExpireByMonthAction(RepositoryFactory.GetRepository<VehicleRepository>()),
                new ReportVehicleTypesCountAction(RepositoryFactory.GetRepository<VehicleRepository>()),
                new ReportEmployeeRents(RepositoryFactory.GetRepository<EmployeeRepository>(), RepositoryFactory.GetRepository<RentRepository>()),
                new ReportRentPriceByRent(RepositoryFactory.GetRepository<RentRepository>()),
                new ReportEmployeeLastRent(RepositoryFactory.GetRepository<EmployeeRepository>()),
                new ReportBrandCount(RepositoryFactory.GetRepository<VehicleRepository>()),
                new ReportNumberOfRentsForMonthByYear(RepositoryFactory.GetRepository<RentRepository>()),
                new ReportAboveAverageRentsForVehicleModels(RepositoryFactory.GetRepository<VehicleModelRepository>()),
                new ExitMenuAction()
            };

            return new ReportsParentAction(actions);
        }        
    }
}
