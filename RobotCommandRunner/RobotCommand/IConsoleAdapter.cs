namespace RobotCommand
{
    public interface IConsoleAdapter
    {
        void WriteLine(string value);
        void WriteLine(string format, object arg0);
    }
}