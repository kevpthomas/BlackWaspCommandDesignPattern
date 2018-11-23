namespace RobotCommand
{
    /// <summary>
    /// Receiver class in the Command pattern. Contains the functionality to support the commands.
    /// </summary>
    /// <remarks>
    /// Receiver objects contain the methods that are executed when one or more commands are invoked.
    /// This allows the actual functionality to be held separately to the Command definitions.
    /// </remarks>
    public class Robot : IRobot
    {
        private readonly IConsoleAdapter _console;

        public Robot(IConsoleAdapter console)
        {
            _console = console;
        }

        public void Move(int forwardDistance)
        {
            if (forwardDistance == 0) return;

            if (forwardDistance > 0)
                _console.WriteLine("Robot moved forwards {0}mm.", forwardDistance);
            else
                _console.WriteLine("Robot moved backwards {0}mm.", -forwardDistance);
        }
 
        public void RotateLeft(double leftRotation)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (leftRotation == 0) return;

            if (leftRotation > 0)
                _console.WriteLine("Robot rotated left {0} degrees.", leftRotation);
            else
                _console.WriteLine("Robot rotated right {0} degrees.", -leftRotation);
        }
 
        public void Scoop(bool upwards)
        {
            _console.WriteLine(upwards ? "Robot gathered soil in scoop." : "Robot released scoop contents.");
        }
    }
}