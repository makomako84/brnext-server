using Microsoft.Extensions.Logging;

public class BarService : IBarService
{
    private readonly IFooService _fooService;
    public BarService(IFooService fooService)
    {
        _fooService = fooService;
    }

    public void DoSomeRealWork()
    {
        for (int i = 0; i < 10; i++)
        {
            _fooService.DoThing(i);
        }
    }
}

public class FooService : IFooService
{
    private readonly ILogger<FooService> _logger;
    public FooService(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<FooService>();
    }

    public void DoThing(int number)
    {
        _logger.LogInformation($"Doing the thing {number}");
    }
}