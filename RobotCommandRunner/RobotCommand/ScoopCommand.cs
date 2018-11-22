namespace RobotCommand
{
    /// <summary>
    /// ConcreteCommand class in the Command pattern. Command for a robot to move a scoop upwards or downwards.
    /// </summary>
    /// <remarks>
    /// Concrete command classes are subclasses of CommandBase (<see cref="RobotCommand"/>).
    /// In addition to implementing the Execute method, they contain all of the information that is required
    /// to correctly perform the action using the linked Receiver object.
    /// </remarks>
    public class ScoopCommand : RobotCommand
    {
        public bool ScoopUpwards { get; set; }
 
        public ScoopCommand(IRobot robot) : base(robot) { }
 
        public override void Execute()
        {
            Robot.Scoop(ScoopUpwards);
        }
 
        public override void Undo()
        {
            Robot.Scoop(!ScoopUpwards);
        }
    }
}