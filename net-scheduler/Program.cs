using net_scheduler;
using Quartz;
using Quartz.Impl;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/", () => "Hello World!");

ISchedulerFactory schedulerFactory = new StdSchedulerFactory();

IScheduler scheduler = await schedulerFactory.GetScheduler();
await scheduler.Start();

IJobDetail job = JobBuilder.Create<SchedulerDemo>()
    .WithIdentity("number generator job", "number generator group")
    .Build();

ITrigger trigger = TriggerBuilder.Create()
    .WithIdentity("number generator trigger", "number generator group")
    .WithSimpleSchedule(x => x.WithIntervalInSeconds(15).WithRepeatCount(3))
    .Build();

await scheduler.ScheduleJob(job, trigger);

app.Run();