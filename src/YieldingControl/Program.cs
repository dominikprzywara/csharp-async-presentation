using System;
using System.Threading.Tasks;
using System.Threading;
namespace YieldingControl
{
     class Program
    {
        static async Task Main(string[] args)
        {
            var delayer = new AsyncDelayer();

            while (true)
            {
                ConsoleHelper.ColorfulMessage(ConsoleColor.Yellow, "Main loop");
                await Task.Delay(150);
                //Left unawaited on puropse
                delayer.DelayForSecond();
            }
        }
    }
}
