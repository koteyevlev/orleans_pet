using System.Threading.Tasks;
using Orleans;

namespace Orleans_Pet
{
    public interface IHelloWorldGrain : IGrainWithStringKey
    {
        Task<string> SayHelloAsync(string name);
    }

}
