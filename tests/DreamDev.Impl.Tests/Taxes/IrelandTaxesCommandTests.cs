using DreamDev.Impl.Commands.Taxes;
using Xunit;

namespace DreamDev.Impl.Tests.Taxes
{
    public class IrelandTaxesCommandTests
    {
        [Theory]
        [InlineData(10, 40, 400)]
        [InlineData(10, 50, 500)]
        [InlineData(10, 60, 600)]
        [InlineData(10, 70, 700)]
        [InlineData(10, 80, 800)]
        public void GetValidIrelandGrossAmount(int workedHours, int hourlyRate, decimal expected)
        {
            var command = new CalculateIrelandTaxesCommand(workedHours, hourlyRate);

            var result = command.GetGrossAmount();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 40, 100)]
        [InlineData(10, 50, 125)]
        [InlineData(10, 60, 150)]
        [InlineData(10, 70, 280)]
        [InlineData(10, 80, 320)]
        public void GetValidIrelandIncomeTax(int workedHours, int hourlyRate, decimal expected)
        {
            var command = new CalculateIrelandTaxesCommand(workedHours, hourlyRate);

            var result = command.GetIncomeTax();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 40, 28)]
        [InlineData(10, 50, 35)]
        [InlineData(10, 60, 48)]
        [InlineData(10, 70, 56)]
        public void GetValidIrelandUniversalSocialCharge(int workedHours, int hourlyRate, decimal expected)
        {
            var command = new CalculateIrelandTaxesCommand(workedHours, hourlyRate);

            var result = command.GetUniversalSocialCharge();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 40, 16)]
        [InlineData(10, 50, 20)]
        [InlineData(10, 60, 24)]
        [InlineData(10, 70, 28)]
        public void GetValidIrelandPension(int workedHours, int hourlyRate, decimal expected)
        {
            var command = new CalculateIrelandTaxesCommand(workedHours, hourlyRate);

            var result = command.GetPension();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 40, 256)]
        [InlineData(10, 50, 320)]
        [InlineData(10, 60, 378)]
        [InlineData(10, 70, 336)]
        public void GetValidIrelandNetAmount(int workedHours, int hourlyRate, decimal expected)
        {
            var command = new CalculateIrelandTaxesCommand(workedHours, hourlyRate);

            var result = command.GetNetAmount();

            Assert.Equal(expected, result);
        }
    }
}
