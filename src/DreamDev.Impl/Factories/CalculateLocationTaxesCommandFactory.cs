using DreamDev.Impl.Commands.Taxes;
using DreamDev.Impl.Enums;
using System;

namespace DreamDev.Impl.Factories
{
    public static class CalculateLocationTaxesCommandFactory
    {
        public static ICalculateLocationTaxesCommand CreateCommand(int workedHours, int hourlyRate, Location employeeLocation)
        {
            switch (employeeLocation)
            {
                case Location.Ireland: return new CalculateIrelandTaxesCommand(workedHours, hourlyRate);
                case Location.Italy: return new CalculateItalyTaxesCommand(workedHours, hourlyRate);
                case Location.Germany: return new CalculateGermanyTaxesCommand(workedHours, hourlyRate);
                default: throw new ArgumentException($"Invalid {nameof(employeeLocation)} option");
            }
        }
    }
}
