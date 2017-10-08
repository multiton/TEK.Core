using System;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TEK.Core.ResourceAccess.EF;

namespace TEK.Core.WebApi.Controllers
{
	[Route("api/[controller]")]
	[EnableCors("AllowSpecificOrigin")]
	public class CompanyController : Controller
    {
        private readonly DataContext dataContext;

        public CompanyController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            Console.Write($"\n--- Got request [{threadId}]...");
            var watch = Stopwatch.StartNew();

            var result = await this.dataContext.Companies
                .OrderBy(x => x.Name)
				.Take(1000000)
				.ToListAsync();

            watch.Stop();
			Console.WriteLine($"[{threadId}] Load from database...({watch.ElapsedMilliseconds} miliSec)");

            return Ok(result);
        }
    }
}