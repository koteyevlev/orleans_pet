using System;
using System.Threading.Tasks;
using Orleans;

namespace Orleans_Pet
{
    public class HelloWorldGrain : Grain<HelloState>, IHelloWorldGrain
    {
        private IDisposable _timer;
        public async Task<string> SayHelloAsync(string name)
        {
            var count = State.InvokationCount++;
            await WriteStateAsync();
            return $"Hello {name} from {this.GetPrimaryKeyString()} - I've said hell {count++}";
        }

        public override Task OnActivateAsync()
        {
            _timer = RegisterTimer(state =>
            {
                Console.WriteLine("Timer is activated");
                return Task.CompletedTask;
            }, null, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(1));
            return base.OnActivateAsync();
        }
    }
}
