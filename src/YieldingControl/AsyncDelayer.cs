using System;
using System.Threading.Tasks;

namespace YieldingControl
{
    class AsyncDelayer
    {
        Task _task;

        public async Task DelayForSecond()
        {
            if (_task?.IsCompleted ?? true)
            {
                ConsoleHelper.ColorfulMessage(ConsoleColor.Red, "Create task");
                _task = Task.Delay(TimeSpan.FromSeconds(1));

                await _task;
                ConsoleHelper.ColorfulMessage(ConsoleColor.Green, "It's done");
            }
        }
    }
}