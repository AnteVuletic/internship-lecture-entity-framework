using System.Collections.Generic;
using Lecture.Domain.Factories;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Actions;
using Lecture.Presentation.Actions.RentActions;

namespace Lecture.Presentation.Factories
{
    public static class RentActionsFactory
    {
        public static RentParentAction GetRentParentAction()
        {
            var actions = new List<IAction>
            {
                new RentAddAction
                (
                    RepositoryFactory.GetRepository<RentRepository>(),
                    RepositoryFactory.GetRepository<VehicleRepository>(),
                    RepositoryFactory.GetRepository<RentRateRepository>(),
                    RepositoryFactory.GetRepository<EmployeeRepository>(),
                    RepositoryFactory.GetRepository<CustomerRepository>()
                ),
                new RentDeleteAction(RepositoryFactory.GetRepository<RentRepository>()),
                new RentRateAddAction(RepositoryFactory.GetRepository<RentRateRepository>()),
                new RentRateDeleteAction(RepositoryFactory.GetRepository<RentRateRepository>()),
                new ExitMenuAction()
            };

            return new RentParentAction(actions);
        }
    }
}
