using System;
using System.Threading.Tasks;
using Orleans;

namespace Orleans_Pet.CallFilter
{
    public class ConsoleWritingOutgoingCallFilter: IOutgoingGrainCallFilter
    {

        public async Task Invoke(IOutgoingGrainCallContext context)
        {
            Console.WriteLine("Hello! i am Outgoing call filter");
            await context.Invoke();
            Console.WriteLine(" I am done with  Outgoing call filter");
        }
    }
}
