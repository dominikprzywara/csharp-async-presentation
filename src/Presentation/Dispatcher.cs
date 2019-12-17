using System.Threading.Tasks;

namespace Presentation
{
    public static class Dispatcher
    {
        public delegate void DispatcherHandler();

        public static Task RunAsync(DispatcherHandler handler)
        {
            return Task.Run(() => handler());
        }
    }
}