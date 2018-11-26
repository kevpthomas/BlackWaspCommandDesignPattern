using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using IoC;

namespace RobotCommand.Runner
{
    public class ConsoleIoCConfig : IoCConfig
    {
        private readonly Lazy<Assembly[]> _iocAssemblies = new Lazy<Assembly[]>(() =>
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            AssemblyLoadContext.Default.LoadFromAssemblyPath(Path.Combine(path, "RobotCommand.Infrastructure.dll"));
            return AppDomain.CurrentDomain.GetAssemblies();
        });

        protected override Assembly[] IocAssemblies => _iocAssemblies.Value;

        public static ConsoleIoCConfig Instance { get; } = new ConsoleIoCConfig();
    }
}