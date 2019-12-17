using System;
using System.Threading.Tasks;

namespace Presentation
{
    public class Eliding
    {
        public Task WithEliding()
        {
            throw new Exception($"{nameof(WithEliding)} method exception!");
            return Task.Delay(1000);
        }

        public async Task WithoutEliding()
        {
            throw new Exception($"{nameof(WithoutEliding)} method exception!");
            await Task.Delay(1000);
        }
    }
}