using RobotCommand;
using RobotCommand.Core;
using RobotCommand.Infrastructure;
using Xbehave;

namespace UnitTests
{
    public class MoveCommandTests : UnitTestBase<MoveCommand>
    {
        [Scenario]
        public void ExecuteMovement(int forwardDistance)
        {
            forwardDistance = Faker.Random.Int(1, 1000);

            $"Given a forward movement distance of {forwardDistance} mm"
                .x(() => TestInstance.ForwardDistance = forwardDistance);

            "When a move command is executed"
                .x(() => TestInstance.Execute());

            "Then the robot is issued a command to move forwards the supplied movement distance"
                .x(() => GetDependency<IRobot>().Verify(d => d.Move(forwardDistance)));
        }

        [Scenario]
        public void UndoMovement(int forwardDistance)
        {
            forwardDistance = Faker.Random.Int(1, 1000);

            $"Given a forward movement distance of {forwardDistance} mm"
                .x(() => TestInstance.ForwardDistance = forwardDistance);

            "When a move command is undone"
                .x(() => TestInstance.Undo());

            "Then the robot is issued a command to move backwards the supplied movement distance"
                .x(() => GetDependency<IRobot>().Verify(d => d.Move(-forwardDistance)));
        }
    }
}