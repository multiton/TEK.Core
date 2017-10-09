using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace TEK.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
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