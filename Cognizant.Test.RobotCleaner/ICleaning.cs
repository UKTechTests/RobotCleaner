using System.Collections.Generic;

namespace Cognizant.Test.RobotCleaner
{
    public interface ICleaning
    {
        bool IsComplete { get; }
        IEnumerable<Command> Commands { get; }
        Command NextCommand();
        void ExecuteNextCommand();
    }
}