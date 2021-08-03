using System;
using NUnit.Framework;
using WeatherGreeting.Models;
using WeatherGreeting.Services;
using WeatherGreetingTests.Services;

namespace WeatherGreetingTests
{
    [TestFixture]
    public class WeatherServiceMetricsDecoratorTests
    {
        [Test]
        public void WeatherServiceMetricsDecoratorTest()
        {
            var sut = new WeatherServiceMetricsDecorator(new MockWeatherService());
            Assert.That(sut.WeatherServiceRequestCount, Is.EqualTo(0));
            sut.FetchWeatherData(new MapPoint(), DateTime.Now);
            Assert.That(sut.WeatherServiceRequestCount, Is.EqualTo(1));
            sut.FetchWeatherData(new MapPoint(), DateTime.Now);
            Assert.That(sut.WeatherServiceRequestCount, Is.EqualTo(2));
        }
    }
}
