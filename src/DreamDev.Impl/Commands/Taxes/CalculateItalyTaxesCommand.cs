using DreamDev.Impl.Enums;
using System;

namespace DreamDev.Impl.Commands.Taxes
{
    public class CalculateItalyTaxesCommand : CalculateLocationTaxesCommand, ICalculateLocationTaxesCommand
    {
        public CalculateItalyTaxesCommand(int workedHours, int hourlyRate)
            : base(workedHours, hourlyRate, Location.Italy)
        {
        }

        public override decimal GetIncomeTax()
        {
            return this.GetGrossAmount() * 0.25m;
        }

        public override decimal GetPension()
        {
            var grossAmount = this.GetGrossAmount();
            var percentage = 0.09m;

            if (grossAmount <= 500)
            {
                return grossAmount * percentage;
            }

            var additionalPercentage = Math.Round((grossAmount - 500) / 100, 0, MidpointRounding.AwayFromZero) / 100;

            return grossAmount * (percentage + additionalPercentage);
        }
    }
}
