using System;
using System.Collections.Generic;
using Lecture.Presentation.Abstractions;

namespace Lecture.Presentation.Actions.RentActions
{
    public class RentParentAction : BaseParentAction
    {
        public RentParentAction(IList<IAction> actions) : base(actions)
        {
            Label = "Manage rents";
        }

        public override void Call()
        {
            Console.WriteLine("Rent management");
            base.Call();
        }
    }
}
