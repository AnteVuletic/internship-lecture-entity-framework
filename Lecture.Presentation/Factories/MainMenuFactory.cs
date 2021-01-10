using System.Collections.Generic;
using Lecture.Presentation.Abstractions;
using Lecture.Presentation.Actions;
using Lecture.Presentation.Extensions;

namespace Lecture.Presentation.Factories
{
    public static class MainMenuFactory
    {
        public static IList<IAction> GetMainMenuActions()
        {
            var actions = new List<IAction>
            {
                CustomerActionsFactory.GetCustomerParentAction(),
                EmployeeActionsFactory.GetEmployeeParentAction(),
                VehicleActionsFactory.GetVehicleParentActions(),
                RentActionsFactory.GetRentParentAction(),
                RegistrationFactory.GetRegistrationParentAction(),
                ReportActionsFactory.GetReportsParentAction(),
                new ExitMenuAction()
            };

            actions.SetActionIndexes();
            return actions;
        }
    }
}
