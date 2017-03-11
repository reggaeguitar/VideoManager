using FakeItEasy;
using LazyEntityGraph.AutoFixture;
using LazyEntityGraph.EntityFramework;
using Ploeh.AutoFixture;
using VideoManager.EntityFramework;

namespace VideoManager.Tests
{
    public class BaseUnitTestClass
    {
        private static Fixture Fixture;

        public BaseUnitTestClass()
        {
            var customization = new LazyEntityGraphCustomization(
                ModelMetadataGenerator.LoadFromCodeFirstContext(str => new VideoManagerContext(str), true));
            Fixture = new Fixture();
            Fixture.Customize(customization);
        }

        public T GetFake<T>()
        {
            var fake = A.Fake<T>();
            return fake;
        }

        public T GetRandom<T>()
        {
            var randomT = Fixture.Create<T>();
            return randomT;
        }

        public string GetRandomString()
        {
            var randomStr = GetRandom<string>();
            return randomStr;
        }

        public int GetRandomInt()
        {
            var randomInt = GetRandom<int>();
            return randomInt;
        }
    }
}
