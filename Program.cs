using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

var builder = new HostApplicationBuilder(args);
builder.Services.AddSingleton<IFooService, FooService>();

var testSection = builder.Configuration.GetSection("ApiSettings:TwitterApiKey");
System.Console.WriteLine(testSection.Value);


using var host = builder.Build();
