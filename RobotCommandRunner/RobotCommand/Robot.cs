using System;

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
        public void Move(int forwardDistance)
        {
            if (forwardDistance > 0)
                Console.WriteLine("Robot moved forwards {0}mm.", forwardDistance);
            else
                Console.WriteLine("Robot moved backwards {0}mm.", -forwardDistance);
        }
 
        public void RotateLeft(double leftRotation)
        {
            if (leftRotation > 0)
                Console.WriteLine("Robot rotated left {0} degrees.", leftRotation);
            else
                Console.WriteLine("Robot rotated right {0} degrees.", -leftRotation);
        }
 
        public void Scoop(bool upwards)
        {
            if (upwards)
                Console.WriteLine("Robot gathered soil in scoop.");
            else
                Console.WriteLine("Robot released scoop contents.");
        }
    }
}