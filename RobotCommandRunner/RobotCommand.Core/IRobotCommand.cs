namespace RobotCommand.Core
{
    public interface IRobotCommand
    {
        void Execute();
        void Undo();
    }
}