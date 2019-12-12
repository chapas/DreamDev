using System;

namespace DreamDev.Impl.Commands
{
    public class GetWorkedHoursCommand
    {
        private readonly Action<string> writeLine;
        private readonly Func<string> readLine;

        public GetWorkedHoursCommand(Action<string> writeLine, Func<string> readLine)
        {
            this.writeLine = writeLine;
            this.readLine = readLine;
        }

        public int Handle()
        {
            this.writeLine("Please enter the hours worked: ");

            if (!int.TryParse(this.readLine(), out var value))
            {
                throw new ArgumentException("Invalid value");
            }

            return value;
        }
    }
}
