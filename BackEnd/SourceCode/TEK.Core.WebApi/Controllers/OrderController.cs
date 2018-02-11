using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TEK.Core.ResourceAccess.EF;

namespace TEK.Core.WebApi.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(DataContext dataContext) : base(dataContext) { }

        [Route("api/[controller]")]
        public async Task<IActionResult> Get()
        {
            var result = await this.dataContext.OrderHeaders
                .OrderBy(x => x.Number).Take(25).ToListAsync();

            return Ok(result);
        }
    }
}