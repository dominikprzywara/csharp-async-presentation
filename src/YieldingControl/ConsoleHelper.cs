using System;
using System.Threading.Tasks;

namespace YieldingControl
{
    static class ConsoleHelper
    {
        public static void ColorfulMessage(ConsoleColor color, string message)
        {
            var originColor = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = originColor;
        }
    }
}