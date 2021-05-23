using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans.Configuration;
using Orleans.Hosting;
using Orleans_Pet.CallFilter;

namespace Orleans_Pet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            .UseOrleans(builder =>
            {
                builder.UseLocalhostClustering();
                builder.AddMemoryGrainStorageAsDefault().AddMemoryGrainStorage("PubSubStore");
                builder.Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "my-first-cluster";
                    options.ServiceId = "my-first-service";
                });
                //builder.AddIncomingGrainCallFilter<ConsoleWritingIncomingCallFilter>();
                //builder.AddOutgoingGrainCallFilter<ConsoleWritingOutgoingCallFilter>();
                //builder.UseAdoNetClustering(options =>
                //{
                 //   options.Invariant = "Npgsql";
                  //  options.ConnectionString = "postgres://postgres:root@localhost:5432/tg_bot";

                //});
            });
    }
}
