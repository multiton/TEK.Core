using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TEK.Core.Entity;
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
			Console.Write("\nGot request...");

			var result = await this.dataContext.Set<Company>()
                .OrderBy(x => x.Name).
				Take(80000).
				ToListAsync();

			Console.WriteLine("Load from database...");

            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.dataContext.Set<Company>()
                .SingleOrDefaultAsync(x => x.Id == id);

            if (result == null) return NotFound($"Id {id} not found");

            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}