namespace RobotCommand.Core
{
    /// <summary>
    /// CommandBase class in the Command pattern. Provides standard contract for robot command execution.
    /// </summary>
    /// <remarks>
    /// This abstract class is the base class for all command objects.
    /// It defines a protected field that holds the Receiver that is linked to the command, which is usually set via a constructor.
    /// The class also defines an abstract method that is used by the Invoker to execute commands.
    /// </remarks>
    public abstract class RobotCommand
    {
        protected IRobot Robot;

        protected RobotCommand(IRobot robot)
        {
            Robot = robot;
        }
 
        public abstract void Execute();
 
        public abstract void Undo();
    }
}
