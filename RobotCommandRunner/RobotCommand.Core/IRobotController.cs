using System.Collections.Generic;

namespace RobotCommand.Core
{
    public interface IRobotController
    {
        void ExecuteCommands();
        void UndoCommands(int numUndos);
        Queue<IRobotCommand> Commands { get; }
    }
}