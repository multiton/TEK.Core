using System;
using System.Linq;
using System.Threading;
using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

using TEK.Core.ResourceAccess.EF;

namespace TEK.Core.WebApi.Controllers
{
    [Produces("application/json")]
    [EnableCors("AllowSpecificOrigin")]
    public class SynchController : Controller
    {
        private readonly DataContext dataContext;

        public SynchController(DataContext dataContext)
        {
            this.dataContext = dataContext;
            Console.Write($"\n--- Synch-Controller constructed ---");
        }

        [Route("api/[controller]/{count:int}")]
        public IActionResult Get(int count)
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            Console.Write($"\n---> Got request. Count: ({count}) Thread: [{threadId}]...");
            var watch = Stopwatch.StartNew();

            var result = this.dataContext.Companies
                .OrderBy(x => x.Name)
                .Take(count)
                .ToList();

            watch.Stop();
            Console.Write($"---> [{threadId}] Load synch...({watch.ElapsedMilliseconds} miliSec)");

            Program.TotalTime += watch.ElapsedMilliseconds;

            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            Console.WriteLine($"--- Controller disposed.");
            base.Dispose(disposing);
        }
    }
}