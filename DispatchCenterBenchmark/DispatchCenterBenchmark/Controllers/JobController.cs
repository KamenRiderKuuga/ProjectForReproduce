using Microsoft.AspNetCore.Mvc;

namespace DispatchCenterBenchmark.Controllers
{
    /// <summary>
    /// 用于计算被调用次数的控制器，每10秒统计一次10秒内被调用的次数，并输出到控制台
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class JobController : ControllerBase
    {
        private static ulong _callCount;
        private static int _recordSecond = 0;
        private static ulong _lastRecordCount = 0;
        private static readonly object _lock = new object();

        /// <summary>
        /// 用于计算被调用次数的控制器，每10秒统计一次10秒内被调用的次数，并输出到控制台
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Call()
        {
            lock (_lock)
            {
                var second = DateTimeOffset.UtcNow.Second;
                if (second % 10 == 0 && _recordSecond != second)
                {
                    _recordSecond = second;
                    Console.WriteLine($"10秒内调用了{_callCount - _lastRecordCount}次");
                    _lastRecordCount = _callCount;
                }
            }

            Interlocked.Increment(ref _callCount);
            return Ok();
        }
    }
}