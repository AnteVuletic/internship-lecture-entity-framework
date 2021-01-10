using System.Collections.Generic;
using Lecture.Domain.Factories;
using Lecture.Domain.Repositories;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Actions;
using Lecture.Presentation.Actions.CustomerActions;

namespace Lecture.Presentation.Factories
{
    public static class CustomerActionsFactory
    {
        public static CustomerParentAction GetCustomerParentAction()
        {
            var customerActions = new List<IAction>
            {
                new CustomerAddAction(RepositoryFactory.GetRepository<CustomerRepository>()),
                new CustomerEditAction(RepositoryFactory.GetRepository<CustomerRepository>()),
                new CustomerDeleteAction(RepositoryFactory.GetRepository<CustomerRepository>()),
                new ExitMenuAction()
            };

            var customerParentAction = new CustomerParentAction(customerActions);
            return customerParentAction;
        }
    }
}
