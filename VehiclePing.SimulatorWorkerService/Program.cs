using VehiclePing.SimulatorWorkerService;
using VehiclePing.SimulatorWorkerService.BackgroundServices;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        //services.AddSingleton<VehiclePingBackgroundService>();
        services.AddHttpClient<VehiclePingBackgroundService>();
        services.AddHostedService<VehiclePingBackgroundService>();


    })
    .Build();

await host.RunAsync();
