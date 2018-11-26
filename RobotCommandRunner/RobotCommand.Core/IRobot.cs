namespace RobotCommand.Core
{
    public interface IRobot
    {
        void Move(int forwardDistance);
        void RotateLeft(double leftRotation);
        void Scoop(bool upwards);
    }
}