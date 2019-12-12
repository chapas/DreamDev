using DreamDev.Impl.Enums;

namespace DreamDev.Impl.Commands.Taxes
{
    public class CalculateIrelandTaxesCommand : CalculateLocationTaxesCommand, ICalculateLocationTaxesCommand
    {
        public CalculateIrelandTaxesCommand(int workedHours, int hourlyRate) 
            : base(workedHours, hourlyRate, Location.Ireland)
        {
        }

        public override decimal GetIncomeTax()
        {
            var grossAmount = this.GetGrossAmount();
            return grossAmount * (grossAmount <= 600 ? 0.25m : 0.40m);
        }

        public override decimal GetPension()
        {
            return this.GetGrossAmount() * 0.04m;
        }

        public override decimal GetUniversalSocialCharge()
        {
            var grossAmount = this.GetGrossAmount();
            return grossAmount * (grossAmount <= 500 ? 0.07m : 0.08m);
        }
    }
}
