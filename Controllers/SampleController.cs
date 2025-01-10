using Microsoft.AspNetCore.Mvc;
using Hangfire;

namespace HangfireDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {
        // Fire-and-forget job
        [HttpGet("fire-once")]
        public IActionResult FireOnce()
        {
            BackgroundJob.Enqueue(() => Console.WriteLine("Fire-and-forget job executed!"));
            return Ok("A fire-and-forget job has been scheduled.");
        }

        // Recurring job
        [HttpGet("recurring")]
        public IActionResult CreateRecurringJob()
        {
            // This job will run every minute for demo. In real usage, you might use Cron.Daily or Cron.Weekly
            RecurringJob.AddOrUpdate("my-recurring-job",
                () => Console.WriteLine("Recurring job runs..."),
                Cron.Minutely);

            return Ok("Recurring job scheduled to run every minute.");
        }
    }
}
