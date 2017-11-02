using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using TEK.Core.Entity;

namespace TEK.Core.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Company")]
    public class CompanyController : Controller
    {
        // GET: api/Company
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Company/5
        [HttpGet("{id}", Name = "Get")]
        public Company Get(int id)
        {
            return new Company { Id = 123, Name = "Big Company" };
        }
    }
}