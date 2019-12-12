using DreamDev.Impl.Commands;
using DreamDev.Impl.Enums;
using System;
using Xunit;

namespace DreamDev.Impl.Tests
{
    public class GetEmployeeLocationCommandTests
    {
        [Theory]
        [InlineData("Ireland")]
        [InlineData("Italy")]
        [InlineData("Germany")]
        public void GetValidWorkedHours(string employeeLocation)
        {
            var writeLine = new Action<string>(message => { });
            var readLine = new Func<string>(() => employeeLocation);
            var command = new GetEmployeeLocationCommand(writeLine, readLine);

            var result = command.Handle();

            var location = (Location)Enum.Parse(typeof(Location), employeeLocation);

            Assert.Equal(location, result);
        }
    }
}
