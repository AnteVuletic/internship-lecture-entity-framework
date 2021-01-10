using System;
using System.Threading;

namespace Lecture.Presentation.Helpers
{
    public static class ReadHelpers
    {
        public static bool TryReadLineIfNotEmpty(out string readValue)
        {
            var readLine = Console.ReadLine();
            if (string.IsNullOrEmpty(readLine))
            {
                readValue = null;
                return false;
            }

            readValue = readLine;
            return true;
        }

        public static bool TryReadNumber(out int number)
        {
            var isNumber = int.TryParse(Console.ReadLine(), out var numberRead);
            if (!isNumber)
            {
                Console.WriteLine("Error not number");
                Thread.Sleep(1000);
                Console.Clear();
                number = 0;
                return false;
            }

            number = numberRead;
            return true;
        }
    }
}
