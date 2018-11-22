using Moq;
using RobotCommand;
using Xbehave;
// ReSharper disable IdentifierTypo

namespace UnitTests
{
    public class RobotTests : UnitTestBase<Robot>
    {
        [Scenario]
        public void MoveForwards(int forwardDistance)
        {
            var distanceMillimetres = Faker.Random.Int(1, 1000);

            $"Given a movement distance of {distanceMillimetres} mm"
                .x(() => forwardDistance = distanceMillimetres);

            "When a robot is issued a command to move"
                .x(() => TestInstance.Move(forwardDistance));

            "Then the robot moves forwards"
                .x(() => GetDependency<IConsoleAdapter>().Verify(m => m.WriteLine("Robot moved forwards {0}mm.", forwardDistance), Times.Once()));
        }

        [Scenario]
        public void MoveBackwards(int backwardDistance)
        {
            var distanceMillimetres = Faker.Random.Int(-1000, -1);

            $"Given a movement distance of {distanceMillimetres} mm"
                .x(() => backwardDistance = distanceMillimetres);

            "When a robot is issued a command to move"
                .x(() => TestInstance.Move(backwardDistance));

            "Then the robot moves backwards"
                .x(() => GetDependency<IConsoleAdapter>().Verify(m => m.WriteLine("Robot moved backwards {0}mm.", -backwardDistance), Times.Once()));
        }

        [Scenario]
        public void RotateLeft(double leftRotation)
        {
            var rotationDegrees = Faker.Random.Double(1, 360);

            $"Given a rotation angle of {rotationDegrees} degrees"
                .x(() => leftRotation = rotationDegrees);

            "When a robot is issued a command to rotate"
                .x(() => TestInstance.RotateLeft(leftRotation));

            "Then the robot rotates left"
                .x(() => GetDependency<IConsoleAdapter>().Verify(m => m.WriteLine("Robot rotated left {0} degrees.", leftRotation), Times.Once()));
        }

        [Scenario]
        public void RotateRight(double rightRotation)
        {
            var rotationDegrees = Faker.Random.Double(-360, -1);

            $"Given a rotation angle of {rotationDegrees} degrees"
                .x(() => rightRotation = rotationDegrees);

            "When a robot is issued a command to rotate"
                .x(() => TestInstance.RotateLeft(rightRotation));

            "Then the robot rotates right"
                .x(() => GetDependency<IConsoleAdapter>().Verify(m => m.WriteLine("Robot rotated right {0} degrees.", -rightRotation), Times.Once()));
        }

        [Scenario]
        public void GatherSoil(bool upwards)
        {
            $"Given a scoop command of {true}"
                .x(() => upwards = true);

            "When a robot is issued a command to scoop"
                .x(() => TestInstance.Scoop(upwards));

            "Then the robot scoops up soil"
                .x(() => GetDependency<IConsoleAdapter>().Verify(m => m.WriteLine("Robot gathered soil in scoop."), Times.Once()));
        }

        [Scenario]
        public void ReleaseScoop(bool downwards)
        {
            $"Given a scoop command of {false}"
                .x(() => downwards = false);

            "When a robot is issued a command to scoop"
                .x(() => TestInstance.Scoop(downwards));

            "Then the robot releases scoop contents"
                .x(() => GetDependency<IConsoleAdapter>().Verify(m => m.WriteLine("Robot released scoop contents."), Times.Once()));
        }
    }
}
