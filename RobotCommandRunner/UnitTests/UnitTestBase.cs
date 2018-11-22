using Bogus;
using Moq;
using Moq.AutoMock;
using Xbehave;

namespace UnitTests
{
    public abstract class UnitTestBase<TUnderTest> where TUnderTest : class
    {
        private AutoMocker _autoMocker;

        protected Faker Faker => new Faker();

        private TUnderTest _testInstance;
        protected TUnderTest TestInstance => _testInstance ?? (_testInstance = _autoMocker.CreateInstance<TUnderTest>());

        protected Mock<T> GetDependency<T>() where T : class 
        {
            return _autoMocker.GetMock<T>();
        }

        [Background]
        public virtual void Setup()
        {
            _testInstance = null;

            _autoMocker = new AutoMocker(MockBehavior.Loose);
        }
    }
}