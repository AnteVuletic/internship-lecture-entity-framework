using System;
using System.Collections.Generic;
using Lecture.Presentation.Abstractions;

namespace Lecture.Presentation.Actions.VehicleActions
{
    public class VehicleParentActions : BaseParentAction
    {
        public VehicleParentActions(IList<IAction> actions) : base(actions)
        {
            Label = "Manage vehicles";
        }

        public override void Call()
        {
            Console.WriteLine("Vehicle managements");
            base.Call();
        }
    }
}
