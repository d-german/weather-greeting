using NUnit.Framework;

namespace WeatherGreetingTests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            const string test = "hello world";
            Assert.That(test, Is.EqualTo("hello world"));
        }
    }
}
