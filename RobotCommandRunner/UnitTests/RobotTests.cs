using Bogus;
using Moq;
using RobotCommand;
using Xbehave;

namespace UnitTests
{
    public class RobotTests
    {
        [Scenario]
        public void MoveForwards(Robot testInstance, int forwardDistance)
        {
            var mockConsole = new Mock<IConsoleAdapter>();

            testInstance = new Robot(mockConsole.Object);

            var distanceMillimetres = new Faker().Random.Int(1, 1000);

            $"Given a movement distance of {distanceMillimetres} mm"
                .x(() => forwardDistance = distanceMillimetres);

            "When a robot is issued a command to move"
                .x(() => testInstance.Move(forwardDistance));

            "Then the robot moves forwards"
                .x(() => mockConsole.Verify(m => m.WriteLine("Robot moved forwards {0}mm.", forwardDistance), Times.Once));
        }

        [Scenario]
        public void MoveBackwards(Robot testInstance, int backwardDistance)
        {
            var mockConsole = new Mock<IConsoleAdapter>();

            testInstance = new Robot(mockConsole.Object);

            var distanceMillimetres = new Faker().Random.Int(-1000, -1);

            $"Given a movement distance of {distanceMillimetres} mm"
                .x(() => backwardDistance = distanceMillimetres);

            "When a robot is issued a command to move"
                .x(() => testInstance.Move(backwardDistance));

            "Then the robot moves backwards"
                .x(() => mockConsole.Verify(m => m.WriteLine("Robot moved backwards {0}mm.", -backwardDistance), Times.Once));
        }

        [Scenario]
        public void RotateLeft(Robot testInstance, double leftRotation)
        {
            var mockConsole = new Mock<IConsoleAdapter>();

            testInstance = new Robot(mockConsole.Object);

            var rotationDegrees = new Faker().Random.Double(1, 360);

            $"Given a rotation angle of {rotationDegrees} degrees"
                .x(() => leftRotation = rotationDegrees);

            "When a robot is issued a command to rotate"
                .x(() => testInstance.RotateLeft(leftRotation));

            "Then the robot rotates left"
                .x(() => mockConsole.Verify(m => m.WriteLine("Robot rotated left {0} degrees.", leftRotation), Times.Once));
        }

        [Scenario]
        public void RotateRight(Robot testInstance, double rightRotation)
        {
            var mockConsole = new Mock<IConsoleAdapter>();

            testInstance = new Robot(mockConsole.Object);

            var rotationDegrees = new Faker().Random.Double(-360, -1);

            $"Given a rotation angle of {rotationDegrees} degrees"
                .x(() => rightRotation = rotationDegrees);

            "When a robot is issued a command to rotate"
                .x(() => testInstance.RotateLeft(rightRotation));

            "Then the robot rotates right"
                .x(() => mockConsole.Verify(m => m.WriteLine("Robot rotated right {0} degrees.", -rightRotation), Times.Once));
        }

        [Scenario]
        public void GatherSoil(Robot testInstance, bool upwards)
        {
            var mockConsole = new Mock<IConsoleAdapter>();

            testInstance = new Robot(mockConsole.Object);

            $"Given a scoop command of {true}"
                .x(() => upwards = true);

            "When a robot is issued a command to scoop"
                .x(() => testInstance.Scoop(upwards));

            "Then the robot scoops up soil"
                .x(() => mockConsole.Verify(m => m.WriteLine("Robot gathered soil in scoop."), Times.Once));
        }

        [Scenario]
        public void ReleaseScoop(Robot testInstance, bool downwards)
        {
            var mockConsole = new Mock<IConsoleAdapter>();

            testInstance = new Robot(mockConsole.Object);

            $"Given a scoop command of {false}"
                .x(() => downwards = false);

            "When a robot is issued a command to scoop"
                .x(() => testInstance.Scoop(downwards));

            "Then the robot releases scoop contents"
                .x(() => mockConsole.Verify(m => m.WriteLine("Robot released scoop contents."), Times.Once));
        }
    }
}
