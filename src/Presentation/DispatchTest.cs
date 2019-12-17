using System;
using System.Threading.Tasks;

namespace Presentation
{
    public class DispatchTest
    {
        public async Task ImportantMethod()
        {
            try
            {
                await Dispatcher.RunAsync(async () => await SomeAction());
                throw new Exception("Exception have been thrown!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private async Task SomeAction()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            Console.WriteLine($"{nameof(SomeAction)} completed.");
        }
    }
}