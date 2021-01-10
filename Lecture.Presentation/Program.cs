using Lecture.Presentation.Extensions;
using Lecture.Presentation.Factories;

namespace Lecture.Presentation
{
    public class Program
    {
        static void Main(string[] args)
        {
            var mainMenuActions = MainMenuFactory.GetMainMenuActions();
            mainMenuActions.PrintActionsAndCall();
        }
    }
}
