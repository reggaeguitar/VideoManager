using FakeItEasy;
using Ploeh.AutoFixture;

namespace VideoManager.Tests
{
    public class BaseUnitTestClass
    {
        private static Fixture Fixture = new Fixture();

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
