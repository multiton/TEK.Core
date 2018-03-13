using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TEK.Core.Entity;
using TEK.Core.ResourceAccess.EF;

namespace TEK.Core.WebApi.Controllers
{
	[Route("api/Company")]
	[Produces("application/json")]
	public class CompanyController : BaseController
    {
        public CompanyController(DataContext dataContext) : base (dataContext) { }

		[HttpGet]
		//[Route("api/[controller]")]
		public async Task<IActionResult> Get()
		{
			var result = await this.dataContext.Companies
				.OrderBy(x => x.Name).Take(25).ToListAsync();

			return Ok(result);
		}

		[HttpGet("{id}")]
		//[Route("api/[controller]/{id:int}")]
		public async Task<Company> Get(int id)
        {
			Console.WriteLine($"Get company {id}");

			return await this.dataContext.Companies.FindAsync(id);
        }

		// DELETE: api/Company/5
		[HttpDelete("{id}")]
		//[Route("api/[controller]/{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var company =
				await this.dataContext.Companies.SingleOrDefaultAsync(m => m.Id == id);

			if (company == null) return NotFound();

			this.dataContext.Companies.Remove(company);
			await this.dataContext.SaveChangesAsync();

			return Ok(company);
		}
	}
}