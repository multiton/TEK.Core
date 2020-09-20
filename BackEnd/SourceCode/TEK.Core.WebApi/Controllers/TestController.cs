using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace TEK.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigins")]
    public class TestController : Controller
    {
        [HttpGet]
        public void Get()
        {
            Console.Clear();
        }
    }
}