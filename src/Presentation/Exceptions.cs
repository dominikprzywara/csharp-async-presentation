using System;
using System.Threading.Tasks;

namespace Presentation
{
    public class Exceptions
    {
        public async Task DownloadA()
        {
            await Task.Delay(1000);
            throw new ArgumentException(nameof(DownloadA));
        }

        public async Task DownloadB()
        {
            await Task.Delay(1200);
            throw new Exception(nameof(DownloadB));
        }

        public async Task DownloadC()
        {
            await Task.Delay(1600);
            throw new Exception(nameof(DownloadC));
        }
    }
}