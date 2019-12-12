using DreamDev.Impl.Commands.Taxes;
using Xunit;

namespace DreamDev.Impl.Tests.Taxes
{
    public class GermanyTaxesCommandTests
    {
        [Theory]
        [InlineData(10, 40, 400)]
        [InlineData(10, 50, 500)]
        [InlineData(10, 60, 600)]
        [InlineData(10, 70, 700)]
        [InlineData(10, 80, 800)]
        public void GetValidGermanyGrossAmount(int workedHours, int hourlyRate, decimal expected)
        {
            var command = new CalculateGermanyTaxesCommand(workedHours, hourlyRate);

            var result = command.GetGrossAmount();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 40, 100)]
        [InlineData(10, 50, 160)]
        [InlineData(10, 60, 192)]
        [InlineData(10, 70, 224)]
        [InlineData(10, 80, 256)]
        public void GetValidGermanyIncomeTax(int workedHours, int hourlyRate, decimal expected)
        {
            var command = new CalculateGermanyTaxesCommand(workedHours, hourlyRate);

            var result = command.GetIncomeTax();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 40, 8)]
        [InlineData(10, 50, 10)]
        [InlineData(10, 60, 12)]
        [InlineData(10, 70, 14)]
        public void GetValidGermanyPension(int workedHours, int hourlyRate, decimal expected)
        {
            var command = new CalculateGermanyTaxesCommand(workedHours, hourlyRate);

            var result = command.GetPension();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 40, 292)]
        [InlineData(10, 50, 330)]
        [InlineData(10, 60, 396)]
        [InlineData(10, 70, 462)]
        public void GetValidGermanyNetAmount(int workedHours, int hourlyRate, decimal expected)
        {
            var command = new CalculateGermanyTaxesCommand(workedHours, hourlyRate);

            var result = command.GetNetAmount();

            Assert.Equal(expected, result);
        }
    }
}
