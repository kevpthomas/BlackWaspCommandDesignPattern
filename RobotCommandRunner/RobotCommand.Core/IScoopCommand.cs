namespace RobotCommand.Core
{
    public interface IScoopCommand : IRobotCommand
    {
        bool ScoopUpwards { get; set; }
    }
}