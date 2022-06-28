using Hangfire.HttpJob.Client;
using System.Diagnostics;
using Xunit.Abstractions;

namespace JobGenerator;

public class HangfireTest
{
    private readonly ITestOutputHelper _output;
    private string _serverUrl = "http://localhost:5000/job";

    public HangfireTest(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact(DisplayName = "创建1000个1秒执行一次的周期性任务")]
    public void AddRecurringJob()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        Stopwatch createJobStopwatch = Stopwatch.StartNew();
        _output.WriteLine($"开始创建任务:{DateTimeOffset.Now}");
        try
        {
            for (int i = 974; i <= 1000; i++)
            {
                createJobStopwatch.Restart();
                // 下面用的是同步的方式，也可以使用异步： await HangfireJobClient.AddRecurringJobAsync
                var result = HangfireJobClient.AddRecurringJob(_serverUrl, new RecurringJob()
                {
                    JobName = $"每秒执行一次{i}",
                    Method = "Get",
                    Data = new { name = "aaa", age = 10 },
                    Url = "http://framework-dispatchcenterbenchmark/Job",
                    Cron = "* * * * * *"
                }, new HangfireServerPostOption
                {
                    BasicUserName = "admin",//这里是hangfire设置的basicauth
                    BasicPassword = "test"//这里是hangfire设置的basicauth
                });

                if (!result.IsSuccess)
                {
                    _output.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(result));
                }
                Assert.True(result.IsSuccess);

                _output.WriteLine($"创建第{i}个任务任务花费时间：{createJobStopwatch.ElapsedMilliseconds}ms");
            }
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            _output.WriteLine($"结束创建任务:{DateTimeOffset.Now}，花费时间{stopwatch.ElapsedMilliseconds}ms");
        }
    }

    [Fact(DisplayName = "删除1000个1秒执行一次的周期性任务")]
    public void RemoveRecurringJob()
    {
        for (int i = 1; i <= 1000; i++)
        {
            var result = HangfireJobClient.RemoveRecurringJob(_serverUrl, $"每秒执行一次{i}", new HangfireServerPostOption
            {
                BasicUserName = "admin",//这里是hangfire设置的basicauth
                BasicPassword = "test"//这里是hangfire设置的basicauth
            });

            Assert.True(result.IsSuccess);
        }
    }
}