using Bogus;
using Moq;
using RobotCommand;
using TinyIoC;
using Xbehave;

namespace UnitTests
{
    public abstract class UnitTestBase<TUnderTest> where TUnderTest : class 
    {
        protected TinyIoCContainer Container;

        protected Faker Faker => new Faker();
                
        protected Mock<IConsoleAdapter> Console;

        private TUnderTest _testInstance;
        protected TUnderTest TestInstance => _testInstance ?? (_testInstance = Container.Resolve<TUnderTest>());

        [Background]
        public virtual void Setup()
        {
            _testInstance = null;

            Console = new Mock<IConsoleAdapter>();

            Container = new TinyIoCContainer();
            Container.AutoRegister(DuplicateImplementationActions.RegisterSingle);

            Container.Register((c, p) => new Robot(Console.Object));
        }
    }
}