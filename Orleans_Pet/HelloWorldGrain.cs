using System;
using System.Threading.Tasks;
using Orleans;

namespace Orleans_Pet
{
    public interface IHelloWorldGrain: IGrainWithStringKey
    {
        Task<string> SayHelloAsync(string name);
    }


    public class HelloWorldGrain : Grain<HelloState>, IHelloWorldGrain
    {
        public async Task<string> SayHelloAsync(string name)
        {
            var count = State.InvokationCount++;
            await WriteStateAsync();
            return $"Hello {name} from {this.GetPrimaryKeyString()} - I've said hell {count++}";
        }
    }

    public class HelloState
    {
        public int InvokationCount { get; set; }
    }

}
