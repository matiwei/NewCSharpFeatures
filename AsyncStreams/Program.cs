using System;
using System.Threading.Tasks;

namespace AsyncStreams
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var test = new AsyncStreamExample();
            await test.Run();
        }
    }
}
