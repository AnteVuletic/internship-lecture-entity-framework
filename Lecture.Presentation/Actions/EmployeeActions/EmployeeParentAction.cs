using System;
using System.Collections.Generic;
using Lecture.Presentation.Abstractions;

namespace Lecture.Presentation.Actions.EmployeeActions
{
    public class EmployeeParentAction : BaseParentAction
    {
        public EmployeeParentAction(IList<IAction> actions) : base(actions)
        {
            Label = "Manage employees";
        }

        public override void Call()
        {
            Console.WriteLine("Employee management");
            base.Call();
        }

    }
}
