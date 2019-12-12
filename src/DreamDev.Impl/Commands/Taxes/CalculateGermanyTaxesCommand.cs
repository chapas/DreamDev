using DreamDev.Impl.Enums;

namespace DreamDev.Impl.Commands.Taxes
{
    public class CalculateGermanyTaxesCommand : CalculateLocationTaxesCommand, ICalculateLocationTaxesCommand
    {
        public CalculateGermanyTaxesCommand(int workedHours, int hourlyRate) 
            : base(workedHours, hourlyRate, Location.Germany)
        {
        }

        public override decimal GetIncomeTax()
        {
            var grossAmount = this.GetGrossAmount();
            return grossAmount * (grossAmount <= 400 ? 0.25m : 0.32m);
        }

        public override decimal GetPension()
        {
            return this.GetGrossAmount() * 0.02m;
        }
    }
}
