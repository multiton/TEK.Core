using System;
using Microsoft.AspNetCore.Mvc;

namespace TEK.Core.WebApi.Controllers
{
    [Route("api/Time")]
    [Produces("application/json")]    
    public class TimeController : Controller
    {
        [HttpGet]
        public long Get()
        {
			var totalTime = Program.TotalTime;
			Program.TotalTime = 0;

			Console.WriteLine($"\nTotal time: {totalTime}");
			return totalTime;
        }
    }
}