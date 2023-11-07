using Devart.Data.PostgreSql;
using Quartz;

namespace net_scheduler;

public class SchedulerDemo: IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        Console.WriteLine($"Your # is: {RandomNumber(1000000, 999999999)}");
        return Task.CompletedTask;
    }
    
    private int RandomNumber(int min, int max)
    {
        var random = new Random();
        return random.Next(min, max);
    }
    
    
}