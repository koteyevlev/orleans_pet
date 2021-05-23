using System;
using System.Threading.Tasks;
using Orleans;

namespace Orleans_Pet.CallFilter
{
    public class ConsoleWritingIncomingCallFilter : IIncomingGrainCallFilter
    {
        public async Task Invoke(IIncomingGrainCallContext context)
        {
            Console.WriteLine("Hello! Start to invoke our grain.");
            await context.Invoke();
            Console.WriteLine(" I am done with invoking");
        }
    }
}
