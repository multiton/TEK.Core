using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TEK.Core.Entity;
using TEK.Core.ResourceAccess.EF;

namespace TEK.Core.WebApi.Controllers
{
	[Route("api/[controller]")]
	public class OrderController : BaseController
    {
        public OrderController(DataContext dataContext) : base(dataContext) { }

		[HttpGet]
		public async Task<IActionResult> Get()
        {
            var result = await this.dataContext.OrderHeaders.Select(x => new
			{
				x.Id, x.Number,	x.IsNew, x.ShippingDate, Customer = new { x.Customer.Id, x.Customer.Name }
			})
			.OrderBy(x => x.Number).Take(25).ToListAsync();

            return Ok(result);
        }

		[HttpGet("{id}")]
		public async Task<OrderHeader> Get(int id)
        {
            return await this.dataContext.OrderHeaders.FindAsync(id);
        }
    }
}