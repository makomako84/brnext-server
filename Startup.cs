using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

public class Startup
    {
        public Startup()
        {
            var configurationBuilder = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = configurationBuilder.Build();

            var TwitterApiKey = config.GetSection("ApiSettings:TwitterApiKey");
            System.Console.WriteLine(TwitterApiKey.Value);

            var serviceProvider = new ServiceCollection()
                .AddLogging(configure => configure.AddConsole())
                .AddSingleton<IFooService, FooService>()
                .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting Application");

            var foo = serviceProvider.GetService<IFooService>();
            foo.DoThing(4);

            logger.LogDebug("All done");

        }
    }