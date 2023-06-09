﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

// // The Host.CreateDefaultBuilder(String[]) method provides default configuration for the app
// // source: https://learn.microsoft.com/en-us/dotnet/core/extensions/configuration
// using IHost host = Host.CreateDefaultBuilder(args).Build();

// await host.RunAsync();



/*
    A host is an object that encapsulates an app's resources and lifetime functionality, such as:
        - Dependency injection (DI)
        - Logging
        - Configuration
        - App shutdown
        - IHostedService implementations
    source: https://learn.microsoft.com/en-us/dotnet/core/extensions/generic-host
*/

// var builder = new HostApplicationBuilder(args);
// builder.Services.AddSingleton<IFooService, FooService>();

// // test config works ...
// var testSection = builder.Configuration.GetSection("ApiSettings:TwitterApiKey");
// System.Console.WriteLine(testSection.Value);


// using var host = builder.Build();

// // Здесь Host встает на ожидание и принимает всякие-разные запросы
// await host.RunAsync();

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging((context, logging) =>
    {
        logging.ClearProviders();

        logging.AddConsole();
    })
    .ConfigureServices(services =>
    {
        services.AddSingleton<IFooService, FooService>();

    }).Build();

// Test IConfiguration works
IConfiguration config = host.Services.GetRequiredService<IConfiguration>();
var testSection = config.GetSection("ApiSettings:TwitterApiKey");
System.Console.WriteLine("Config value is: " + testSection.Value);


// Test service works
var run = host.Services.GetRequiredService<IFooService>();
run.DoThing(4);




// Run host here ...
await host.RunAsync();