﻿namespace RobotCommand
{
    /// <summary>
    /// ConcreteCommand class in the Command pattern. Command for a robot to move forward or backward.
    /// </summary>
    /// <remarks>
    /// Concrete command classes are subclasses of CommandBase (<see cref="RobotCommand"/>).
    /// In addition to implementing the Execute method, they contain all of the information that is required
    /// to correctly perform the action using the linked Receiver object.
    /// </remarks>
    public class MoveCommand : RobotCommand
    {
        public int ForwardDistance { get; set; }
 
        public MoveCommand(Robot robot) : base(robot) { }
 
        public override void Execute()
        {
            Robot.Move(ForwardDistance);
        }
 
        public override void Undo()
        {
            Robot.Move(-ForwardDistance);
        }
    }
}