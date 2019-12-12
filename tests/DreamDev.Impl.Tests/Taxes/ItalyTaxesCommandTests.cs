using DreamDev.Impl.Commands.Taxes;
using Xunit;

namespace DreamDev.Impl.Tests.Taxes
{
    public class ItalyTaxesCommandTests
    {
        [Theory]
        [InlineData(10, 40, 400)]
        [InlineData(10, 50, 500)]
        [InlineData(10, 60, 600)]
        [InlineData(10, 70, 700)]
        [InlineData(10, 80, 800)]
        public void GetValidItalyGrossAmount(int workedHours, int hourlyRate, decimal expected)
        {
            var command = new CalculateItalyTaxesCommand(workedHours, hourlyRate);

            var result = command.GetGrossAmount();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 40, 100)]
        [InlineData(10, 50, 125)]
        [InlineData(10, 60, 150)]
        [InlineData(10, 70, 175)]
        [InlineData(10, 80, 200)]
        public void GetValidItalyIncomeTax(int workedHours, int hourlyRate, decimal expected)
        {
            var command = new CalculateItalyTaxesCommand(workedHours, hourlyRate);

            var result = command.GetIncomeTax();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 10, 9)]
        [InlineData(10, 25, 22.5)]
        [InlineData(10, 50, 45)]
        [InlineData(10, 60, 60)]
        [InlineData(10, 70, 77)]
        [InlineData(10, 75, 90)]
        [InlineData(10, 80, 96)]
        [InlineData(10, 90, 117)]
        public void GetValidItalyPension(int workedHours, int hourlyRate, decimal expected)
        {
            var command = new CalculateItalyTaxesCommand(workedHours, hourlyRate);

            var result = command.GetPension();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 40, 264)]
        [InlineData(10, 50, 330)]
        [InlineData(10, 60, 390)]
        [InlineData(10, 70, 448)]
        public void GetValidItalyNetAmount(int workedHours, int hourlyRate, decimal expected)
        {
            var command = new CalculateItalyTaxesCommand(workedHours, hourlyRate);

            var result = command.GetNetAmount();

            Assert.Equal(expected, result);
        }
    }
}
