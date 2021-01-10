using System.Collections.Generic;
using Lecture.Domain.Factories;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Actions;
using Lecture.Presentation.Actions.RegistrationActions;

namespace Lecture.Presentation.Factories
{
    public static class RegistrationFactory
    {
        public static RegistrationParentAction GetRegistrationParentAction()
        {
            var actions = new List<IAction>
            {
                new RegistrationAddAction(RepositoryFactory.GetRepository<RegistrationRepository>(), RepositoryFactory.GetRepository<VehicleRepository>()),
                new RegistrationDeleteAction(RepositoryFactory.GetRepository<RegistrationRepository>()),
                new ExitMenuAction()
            };

            return new RegistrationParentAction(actions);
        }
    }
}
