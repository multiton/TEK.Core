using System;
using Microsoft.AspNetCore.Mvc;

namespace TEK.Core.WebApi.Controllers
{
    [Route("api/Test")]
    [Produces("application/json")]    
    public class TestController : Controller
    {
        [HttpGet]
        public string Get()
        {
            Console.Clear();
            return string.Empty;
        }
    }
}