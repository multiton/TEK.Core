using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using TEK.Core.ResourceAccess.EF;

namespace TEK.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]    
    [EnableCors("AllowSpecificOrigins")]
    public class BaseController : Controller
    {
        protected readonly DataContext dataContext;

        public BaseController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
    }
}