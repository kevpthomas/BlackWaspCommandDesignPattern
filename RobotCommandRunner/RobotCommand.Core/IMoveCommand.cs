namespace RobotCommand.Core
{
    public interface IMoveCommand : IRobotCommand
    {
        int ForwardDistance { get; set; }
    }
}