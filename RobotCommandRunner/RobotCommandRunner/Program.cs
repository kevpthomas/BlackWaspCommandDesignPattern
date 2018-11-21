using System;
using RobotCommand;

namespace RobotCommandRunner
{
    /// <summary>
    /// Client class in the Command pattern.
    /// </summary>
    /// <remarks>
    /// The class is a consumer of the classes of the command design pattern.
    /// It creates the command objects and links them to receivers.
    /// </remarks>
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            var robot = new Robot();
            var controller = new RobotController();

            var move = new MoveCommand(robot) {ForwardDistance = 1000};
            controller.Commands.Enqueue(move);

            var rotate = new RotateCommand(robot) {LeftRotation = 45};
            controller.Commands.Enqueue(rotate);

            var scoop = new ScoopCommand(robot) {ScoopUpwards = true};
            controller.Commands.Enqueue(scoop);
 
            controller.ExecuteCommands();
            controller.UndoCommands(3);

            Console.Read();
        }
    }
}
