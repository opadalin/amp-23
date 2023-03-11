using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Cosmos;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureAppConfiguration(configBuilder =>
    {
        configBuilder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("local.settings.json")
            .AddEnvironmentVariables();
    })
    .ConfigureServices((context, services) =>
    {
        var config = context.Configuration;
        services.AddSingleton(_ => new CosmosClient(config["CosmosDBConnectionString"]));
    })
    .Build();

await host.RunAsync();