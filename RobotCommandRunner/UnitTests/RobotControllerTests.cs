using Moq.Sequences;
using RobotCommand;
using RobotCommand.Core;
using Shouldly;
using Xbehave;
// ReSharper disable RedundantAssignment

namespace UnitTests
{
    public class RobotControllerTests : UnitTestBase<RobotController>
    {
        [Scenario]
        public void ExecuteCommands(RobotCommand.Core.RobotCommand robotCommand1, RobotCommand.Core.RobotCommand robotCommand2)
        {
            var sequence = Sequence.Create();

            robotCommand1 = CreateMock<RobotCommand.Core.RobotCommand>(args: CreateMock<IRobot>());
            robotCommand2 = CreateMock<RobotCommand.Core.RobotCommand>(args: CreateMock<IRobot>());

            robotCommand1.Setup(x => x.Execute()).InSequence();
            robotCommand2.Setup(x => x.Execute()).InSequence();

            "Given a first command is issued"
                .x(() => TestInstance.Commands.Enqueue(robotCommand1));

            "And a second command is issued"
                .x(() => TestInstance.Commands.Enqueue(robotCommand2));

            "When the commands are executed"
                .x(() => TestInstance.ExecuteCommands());

            "Then the commands are executed in the issue sequence"
                .x(() => Should.NotThrow(() => sequence.Dispose(), "Commands should have been executed in order, but were not."));
        }

        [Scenario]
        public void UndoCommands(RobotCommand.Core.RobotCommand robotCommand1, RobotCommand.Core.RobotCommand robotCommand2)
        {
            var sequence = Sequence.Create();

            robotCommand1 = CreateMock<RobotCommand.Core.RobotCommand>(args: CreateMock<IRobot>());
            robotCommand2 = CreateMock<RobotCommand.Core.RobotCommand>(args: CreateMock<IRobot>());

            robotCommand1.Setup(x => x.Execute()).InSequence();
            robotCommand2.Setup(x => x.Execute()).InSequence();
            robotCommand2.Setup(x => x.Undo()).InSequence();
            robotCommand1.Setup(x => x.Undo()).InSequence();

            "Given a first command is issued"
                .x(() => TestInstance.Commands.Enqueue(robotCommand1));

            "And a second command is issued"
                .x(() => TestInstance.Commands.Enqueue(robotCommand2));

            "When the commands are executed"
                .x(() => TestInstance.ExecuteCommands());

            "And then the commands are undone"
                .x(() => TestInstance.UndoCommands(2));

            "Then the commands are executed in the issue sequence and undone in reverse order"
                .x(() => Should.NotThrow(() => sequence.Dispose(), "Commands should have been executed and then undone in order, but were not."));
        }
    }
}