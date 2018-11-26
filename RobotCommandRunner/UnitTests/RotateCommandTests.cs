using RobotCommand;
using RobotCommand.Core;
using Xbehave;

namespace UnitTests
{
    public class RotateCommandTests : UnitTestBase<RotateCommand>
    {
        [Scenario]
        public void ExecuteRotation(double leftRotation)
        {
            leftRotation = Faker.Random.Double(1, 360);

            $"Given a rotation angle of {leftRotation} degrees"
                .x(() => TestInstance.LeftRotation = leftRotation);

            "When a rotate command is executed"
                .x(() => TestInstance.Execute());

            "Then the robot is issued a command to rotate left the supplied rotation angle"
                .x(() => GetDependency<IRobot>().Verify(d => d.RotateLeft(leftRotation)));
        }

        [Scenario]
        public void UndoRotation(double leftRotation)
        {
            leftRotation = Faker.Random.Double(1, 360);

            $"Given a rotation angle of {leftRotation} degrees"
                .x(() => TestInstance.LeftRotation = leftRotation);

            "When a rotate command is undone"
                .x(() => TestInstance.Undo());

            "Then the robot is issued a command to rotate right the supplied rotation angle"
                .x(() => GetDependency<IRobot>().Verify(d => d.RotateLeft(-leftRotation)));
        }
    }
}