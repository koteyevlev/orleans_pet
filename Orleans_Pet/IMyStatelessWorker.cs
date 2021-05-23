using System.Threading.Tasks;
using Orleans;

namespace Orleans_Pet
{
    public interface IMyStatelessWorker: IGrainWithIntegerKey
    {
        Task<double> ComputeNextNumberAsync();
    }
}
