using RobotCommand;
using RobotCommand.Core;
using Xbehave;

namespace UnitTests
{
    public class ScoopCommandTests : UnitTestBase<ScoopCommand>
    {
        [Scenario]
        public void ExecuteScoop()
        {
            const bool scoopUpwards = true;

            $"Given a scoop upwards command of {scoopUpwards}"
                .x(() => TestInstance.ScoopUpwards = scoopUpwards);

            "When a scoop command is executed"
                .x(() => TestInstance.Execute());

            "Then the robot is issued a command to scoop"
                .x(() => GetDependency<IRobot>().Verify(d => d.Scoop(scoopUpwards)));
        }

        [Scenario]
        public void UndoScoop()
        {
            const bool scoopUpwards = true;

            $"Given a scoop upwards command of {scoopUpwards}"
                .x(() => TestInstance.ScoopUpwards = scoopUpwards);

            "When a scoop command is undone"
                .x(() => TestInstance.Undo());

            "Then the robot is issued a command to release scoop contents"
                .x(() => GetDependency<IRobot>().Verify(d => d.Scoop(!scoopUpwards)));
        }
    }
}