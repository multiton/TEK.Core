﻿using System;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;

using TEK.Core.ResourceAccess.EF;

namespace TEK.Core.WebApi.Controllers
{
    [Produces("application/json")]
    [EnableCors("AllowSpecificOrigins")]
	public class AsynchController : Controller
    {
        private readonly DataContext dataContext;

        public AsynchController(DataContext dataContext)
        {
            this.dataContext = dataContext;
            Console.Write("\n== Controller constructed ==");
        }

		[Route("api/[controller]/{count:int}")]
        public async Task<IActionResult> Get(int count)
        {
			var threadId = Thread.CurrentThread.ManagedThreadId;
            Console.Write($"--> Loading ({count} records). Thread: [{threadId}]--..");
            var watch = Stopwatch.StartNew();

            var result = await this.dataContext.Companies
                .OrderBy(x => x.Name)
                .Take(count)
                .ToListAsync();

			watch.Stop();
            Console.WriteLine($"..--> [{threadId}] Loaded aSynch ({watch.ElapsedMilliseconds} miliSec).");

            Program.TotalTime += watch.ElapsedMilliseconds;

            return Ok(result);
        }
    }
}