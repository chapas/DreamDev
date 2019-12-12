using DreamDev.Impl.Enums;
using System;

namespace DreamDev.Impl.Commands
{
    public class GetEmployeeLocationCommand
    {
        private readonly Action<string> writeLine;
        private readonly Func<string> readLine;

        public GetEmployeeLocationCommand(Action<string> writeLine, Func<string> readLine)
        {
            this.writeLine = writeLine;
            this.readLine = readLine;
        }

        public Location Handle()
        {
            this.writeLine("Please enter the employee's location: ");

            if (!Enum.TryParse<Location>(this.readLine(), true, out var location))
            {
                throw new ArgumentException("Invalid value");
            }

            return location;
        }
    }
}
