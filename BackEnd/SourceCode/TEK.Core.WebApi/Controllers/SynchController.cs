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
            Console.Write("\n== Controller constructed ==");
        }

        [Route("api/[controller]/{count:int}")]
        public IActionResult Get(int count)
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            Console.Write($"--> Loading ({count} records). Thread: [{threadId}]--..");
            var watch = Stopwatch.StartNew();

            var result = this.dataContext.Companies
                .OrderBy(x => x.Name)
                .Take(count)
                .ToList();

            watch.Stop();
            Console.WriteLine($"..--> [{threadId}] Loaded Synch ({watch.ElapsedMilliseconds} miliSec).");

            Program.TotalTime += watch.ElapsedMilliseconds;

            return Ok(result);
        }
    }
}