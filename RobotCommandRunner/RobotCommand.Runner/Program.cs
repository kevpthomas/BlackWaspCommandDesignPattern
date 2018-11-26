using System;
using RobotCommand.Core;
using TinyIoC;

namespace RobotCommand.Runner
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
            ConsoleIoCConfig.Instance.Register();

            Console.Clear();

            var controller = TinyIoCContainer.Current.Resolve<IRobotController>();

            var move = TinyIoCContainer.Current.Resolve<IMoveCommand>();
            move.ForwardDistance = 1000;
            controller.Commands.Enqueue(move);

            var rotate = TinyIoCContainer.Current.Resolve<IRotateCommand>();
            rotate.LeftRotation = 45;
            controller.Commands.Enqueue(rotate);

            var scoop = TinyIoCContainer.Current.Resolve<IScoopCommand>();
            scoop.ScoopUpwards = true;
            controller.Commands.Enqueue(scoop);

            controller.ExecuteCommands();
            controller.UndoCommands(3);

            Console.Read();
        }
    }
}
