using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TEK.Core.Entity;
using TEK.Core.ResourceAccess.EF;

namespace TEK.Core.WebApi.Controllers
{
	public class CompanyController : BaseController
    {
        public CompanyController(DataContext dataContext) : base (dataContext) { }

		[Route("api/[controller]")]
		public async Task<IActionResult> Get()
		{
			var result = await this.dataContext.Companies
				.OrderBy(x => x.Name).Take(25).ToListAsync();

			return Ok(result);
		}

		[Route("api/[controller]/{id:int}")]
		public async Task<Company> Get(int id)
        {
			Console.WriteLine($"Get company {id}");

			return await this.dataContext.Companies.FindAsync(id);
        }
    }
}