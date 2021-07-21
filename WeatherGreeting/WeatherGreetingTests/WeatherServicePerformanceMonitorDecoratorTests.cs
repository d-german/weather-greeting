using System;
using NUnit.Framework;
using WeatherGreeting.Models;
using WeatherGreeting.Services;

namespace WeatherGreetingTests
{
    internal class MockPerformanceService : PerformanceServiceBase
    {
        internal long MockRecordedMilliseconds { get; private set; }
        internal long MockElapsedMilliseconds { get; set; }
        internal bool MockRestartCalled { get; set; } = false;

        public override long ElapsedMilliseconds()
        {
            return MockElapsedMilliseconds;
        }

        public override void Restart()
        {
            MockRestartCalled = true;
        }

        public override void Record(long milliseconds)
        {
            MockRecordedMilliseconds = milliseconds;
        }
    }

    internal class MockIWeatherService : IWeatherService
    {
        public WeatherData FetchWeatherData(MapPoint mapPoint, DateTime dateTime)
        {
            return new WeatherData(); // don't care
        }
    }

    [TestFixture]
    public class WeatherServicePerformanceMonitorDecoratorTests
    {
        [Test]
        public void FetchWeatherDataTest()
        {
            var weatherServiceDecoratee = new MockWeatherService();
            var mockPerformanceService = new MockPerformanceService();
            var sut = new WeatherServicePerformanceMonitorDecorator(weatherServiceDecoratee, mockPerformanceService);
            const long elapsedMilliseconds = 256;
            mockPerformanceService.MockElapsedMilliseconds = elapsedMilliseconds;
            sut.FetchWeatherData(new MapPoint(), new DateTime());

            Assert.That(mockPerformanceService.MockRecordedMilliseconds, Is.EqualTo(elapsedMilliseconds));
            Assert.That(mockPerformanceService.MockRestartCalled, Is.True);


        }
    }
}
