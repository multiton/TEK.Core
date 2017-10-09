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
            return Program.TotalTime;
        }
    }
}