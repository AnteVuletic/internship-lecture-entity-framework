using System.Collections.Generic;
using Lecture.Domain.Factories;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Actions;
using Lecture.Presentation.Actions.EmployeeActions;

namespace Lecture.Presentation.Factories
{
    public static class EmployeeActionsFactory
    {
        public static EmployeeParentAction GetEmployeeParentAction()
        {
            var actions = new List<IAction>
            {
                new EmployeeAddAction(RepositoryFactory.GetRepository<EmployeeRepository>()),
                new EmployeeEditAction(RepositoryFactory.GetRepository<EmployeeRepository>()),
                new EmployeeDeleteAction(RepositoryFactory.GetRepository<EmployeeRepository>()),
                new ExitMenuAction()
            };

            return new EmployeeParentAction(actions);
        }
    }
}
