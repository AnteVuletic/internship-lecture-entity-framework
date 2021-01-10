using System.Collections.Generic;

namespace Lecture.Presentation.Abstractions
{
    public interface IParentAction : IAction
    {
        IList<IAction> Actions { get; set; }
    }
}
