namespace DreamDev.Impl.Commands.Taxes
{
    public interface ICalculateLocationTaxesCommand
    {
        string LocationName { get; }
        decimal GetGrossAmount();
        decimal GetIncomeTax();
        decimal GetUniversalSocialCharge();
        decimal GetPension();
        decimal GetNetAmount();
    }
}
