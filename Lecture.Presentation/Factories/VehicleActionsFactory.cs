using System.Collections.Generic;
using Lecture.Domain.Factories;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Actions;
using Lecture.Presentation.Actions.VehicleActions;

namespace Lecture.Presentation.Factories
{
    public class VehicleActionsFactory
    {
        public static VehicleParentActions GetVehicleParentActions()
        {
            var actions = new List<IAction>
            {
                new VehicleAddAction(RepositoryFactory.GetRepository<VehicleRepository>(), RepositoryFactory.GetRepository<VehicleModelRepository>()),
                new VehicleDeleteAction(RepositoryFactory.GetRepository<VehicleRepository>()),
                new VehicleModelAddAction(RepositoryFactory.GetRepository<VehicleModelRepository>(), RepositoryFactory.GetRepository<VehicleBrandRepository>()),
                new VehicleModelDeleteAction(RepositoryFactory.GetRepository<VehicleModelRepository>()),
                new VehicleBrandAddAction(RepositoryFactory.GetRepository<VehicleBrandRepository>()),
                new VehicleBrandDeleteAction(RepositoryFactory.GetRepository<VehicleBrandRepository>()),
                new ExitMenuAction()
            };

            return new VehicleParentActions(actions);
        }
    }
}
