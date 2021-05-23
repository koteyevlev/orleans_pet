using System;
using System.Threading.Tasks;
using Orleans;
using Orleans.Concurrency;

namespace Orleans_Pet
{

    [StatelessWorker]
    public class MyStatelessWorker : Grain, IMyStatelessWorker
    {
        public async Task<double> ComputeNextNumberAsync()
        {
            var random = new Random();
            await Task.Delay(random.Next(1000, 5000));
            return random.NextDouble();
        }
    }
}
