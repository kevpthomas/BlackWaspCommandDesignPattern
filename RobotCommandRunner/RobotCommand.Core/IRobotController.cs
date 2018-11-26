namespace RobotCommand.Core
{
    public interface IRobotController
    {
        void ExecuteCommands();
        void UndoCommands(int numUndos);
    }
}