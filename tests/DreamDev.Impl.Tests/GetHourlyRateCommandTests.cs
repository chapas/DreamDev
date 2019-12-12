using DreamDev.Impl.Commands;
using System;
using Xunit;

namespace DreamDev.Impl.Tests
{
    public class GetHourlyRateCommandTests
    {
        [Theory]
        [InlineData("10")]
        [InlineData("25")]
        [InlineData("50")]
        public void GetValidHourlyRate(string hourlyRate)
        {
            var writeLine = new Action<string>(message => { });
            var readLine = new Func<string>(() => hourlyRate);
            var command = new GetHourlyRateCommand(writeLine, readLine);

            var result = command.Handle();

            Assert.Equal(int.Parse(hourlyRate), result);
        }

        [Theory]
        [InlineData("test")]
        public void GetInvalidWorkedHours(string hourlyRate)
        {
            var writeLine = new Action<string>(message => { });
            var readLine = new Func<string>(() => hourlyRate);
            var command = new GetHourlyRateCommand(writeLine, readLine);

            Assert.Throws<ArgumentException>(() => command.Handle());
        }
    }
}
