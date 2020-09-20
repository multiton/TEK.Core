using System;
using Microsoft.AspNetCore.Mvc;

namespace TEK.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        [HttpGet]
        public void Get()
        {
            Console.Clear();
        }
    }
}