using DreamDev.Impl.Commands;
using System;
using Xunit;

namespace DreamDev.Impl.Tests
{
    public class GetWorkedHoursCommandTests
    {
        [Theory]
        [InlineData("4")]
        [InlineData("6")]
        [InlineData("8")]
        [InlineData("10")]
        [InlineData("400")]
        public void GetValidWorkedHours(string workedHours)
        {
            var writeLine = new Action<string>(message => { });
            var readLine = new Func<string>(() => workedHours);
            var command = new GetWorkedHoursCommand(writeLine, readLine);

            var result = command.Handle();

            Assert.Equal(int.Parse(workedHours), result);
        }

        [Theory]
        [InlineData("4.2")]
        [InlineData("4,2")]
        [InlineData("test")]
        public void GetInvalidWorkedHours(string workedHours)
        {
            var writeLine = new Action<string>(message => { });
            var readLine = new Func<string>(() => workedHours);
            var command = new GetWorkedHoursCommand(writeLine, readLine);

            Assert.Throws<ArgumentException>(() => command.Handle());
        }
    }
}
