namespace RobotCommand
{
    /// <summary>
    /// ConcreteCommand class in the Command pattern. Command for a robot to rotate left or right.
    /// </summary>
    /// <remarks>
    /// Concrete command classes are subclasses of CommandBase (<see cref="RobotCommand"/>).
    /// In addition to implementing the Execute method, they contain all of the information that is required
    /// to correctly perform the action using the linked Receiver object.
    /// </remarks>
    public class RotateCommand : RobotCommand
    {
        public double LeftRotation { get; set; }
 
        public RotateCommand(IRobot robot) : base(robot) { }
 
        public override void Execute()
        {
            Robot.RotateLeft(LeftRotation);
        }
 
        public override void Undo()
        {
            Robot.RotateLeft(-LeftRotation);
        }
    }
}