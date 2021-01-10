using System;
using System.Collections.Generic;
using Lecture.Presentation.Abstractions;

namespace Lecture.Presentation.Actions.RegistrationActions
{
    public class RegistrationParentAction : BaseParentAction
    {
        public RegistrationParentAction(IList<IAction> actions) : base(actions)
        {
            Label = "Manage registrations";
        }

        public override void Call()
        {
            Console.WriteLine("Registrations management");
            base.Call();
        }
    }
}
