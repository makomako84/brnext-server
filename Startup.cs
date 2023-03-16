using Microsoft.Extensions.Configuration;

public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            var TwitterApiKey = config.GetSection("ApiSettings:TwitterApiKey");
            System.Console.WriteLine(TwitterApiKey.Value);

        }
    }