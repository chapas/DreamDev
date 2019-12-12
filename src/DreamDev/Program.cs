using DreamDev.Impl.Commands;
using DreamDev.Impl.Commands.Taxes;
using DreamDev.Impl.Enums;
using DreamDev.Impl.Factories;
using System;
using System.Text;

namespace DreamDev
{
    class Program
    {
        static void Main()
        {
            var workedHours = GetWorkedHours();
            var hourlyRate = GetHourlyRate();
            var employeeLocation = GetEmployeeLocation();

            var locationTaxesCommand = CalculateLocationTaxesCommandFactory.CreateCommand(workedHours, hourlyRate, employeeLocation);

            ShowTaxes(locationTaxesCommand);
        }

        private static int GetWorkedHours()
        {
            var command = new GetWorkedHoursCommand(Console.WriteLine, Console.ReadLine);
            return command.Handle();
        }

        private static int GetHourlyRate()
        {
            var command = new GetHourlyRateCommand(Console.WriteLine, Console.ReadLine);
            return command.Handle();
        }

        private static Location GetEmployeeLocation()
        {
            var command = new GetEmployeeLocationCommand(Console.WriteLine, Console.ReadLine);
            return command.Handle();
        }

        private static void ShowTaxes(ICalculateLocationTaxesCommand calculateLocationTaxesCommand)
        {
            Console.OutputEncoding = Encoding.Default;
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Employee location: {calculateLocationTaxesCommand.LocationName}{Environment.NewLine}");
            Console.WriteLine($"Gross Amount: €{calculateLocationTaxesCommand.GetGrossAmount()}{Environment.NewLine}");
            Console.WriteLine($"Less deductions{Environment.NewLine}");
            Console.WriteLine($"Income Tax: €{calculateLocationTaxesCommand.GetIncomeTax()}");
            Console.WriteLine($"Universal Social Charge: €{calculateLocationTaxesCommand.GetUniversalSocialCharge()}");
            Console.WriteLine($"Pension: €{calculateLocationTaxesCommand.GetPension()}");
            Console.WriteLine($"Net Amount: €{calculateLocationTaxesCommand.GetNetAmount()}");

            Console.ReadKey();
        }
    }
}
