using System.Collections.Generic;
using RobotCommand.Core;

namespace RobotCommand.Infrastructure
{
    /// <summary>
    /// Invoker class in the Command pattern. Provides mechanism to invoke a sequence of one or more commands,
    /// with additional undo functionality.
    /// </summary>
    /// <remarks>
    /// The Invoker object initiates the execution of commands.
    /// The invoker could be controlled by the Client object, as in the example code below.
    /// However, the invoker may be disconnected from the client.
    /// For example, the client could create a queue of commands that are executed periodically by a timed event.
    /// </remarks>
    public class RobotController : IRobotController
    {
        private readonly Stack<IRobotCommand> _undoStack;
        private readonly IConsoleAdapter _console;

        public Queue<IRobotCommand> Commands { get; }

        public RobotController(IConsoleAdapter console)
        {
            _console = console;
            Commands = new Queue<IRobotCommand>();
            _undoStack = new Stack<IRobotCommand>();
        }
 
        public void ExecuteCommands()
        {
            _console.WriteLine("EXECUTING COMMANDS.");
 
            while (Commands.Count > 0)
            {
                var command = Commands.Dequeue();
                command.Execute();
                _undoStack.Push(command);
            }
        }
 
        public void UndoCommands(int numUndos)
        {
            _console.WriteLine("REVERSING {0} COMMAND(S).", numUndos);
 
            while (numUndos > 0 && _undoStack.Count > 0)
            {
                var command = _undoStack.Pop();
                command.Undo();
                numUndos--;
            }
        }
    }}