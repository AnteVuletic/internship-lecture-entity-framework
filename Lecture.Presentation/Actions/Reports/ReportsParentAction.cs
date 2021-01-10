using System.Collections.Generic;
using Lecture.Presentation.Abstractions;

namespace Lecture.Presentation.Actions.Reports
{
    public class ReportsParentAction : BaseParentAction
    {
        public ReportsParentAction(IList<IAction> actions) : base(actions)
        {
            Label = "Reports";
        }
    }
}
