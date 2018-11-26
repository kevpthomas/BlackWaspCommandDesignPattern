namespace RobotCommand.Core
{
    public interface IRotateCommand : IRobotCommand
    {
        double LeftRotation { get; set; }
    }
}