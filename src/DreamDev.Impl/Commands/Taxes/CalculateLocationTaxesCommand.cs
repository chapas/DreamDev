using DreamDev.Impl.Enums;

namespace DreamDev.Impl.Commands.Taxes
{
    public abstract class CalculateLocationTaxesCommand : ICalculateLocationTaxesCommand
    {
        private readonly int workedHours;
        private readonly int hourlyRate;

        public CalculateLocationTaxesCommand(int workedHours, int hourlyRate, Location location)
        {
            this.workedHours = workedHours;
            this.hourlyRate = hourlyRate;
            this.LocationName = location.ToString();
        }

        public string LocationName { get; private set; }

        public decimal GetGrossAmount()
        {
            return this.workedHours * this.hourlyRate;
        }

        public virtual decimal GetIncomeTax()
        {
            return 0m;
        }

        public virtual decimal GetPension()
        {
            return 0m;
        }

        public virtual decimal GetUniversalSocialCharge()
        {
            return 0m;
        }

        public virtual decimal GetNetAmount()
        {
            return this.GetGrossAmount() - this.GetIncomeTax() - this.GetUniversalSocialCharge() - this.GetPension();
        }
    }
}
