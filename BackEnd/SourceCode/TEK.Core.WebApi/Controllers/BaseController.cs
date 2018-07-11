using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using TEK.Core.ResourceAccess.EF;

namespace TEK.Core.WebApi.Controllers
{
    [Produces("application/json")]
    [EnableCors("AllowAnyOrigin")]
    public class BaseController : Controller
    {
        protected readonly DataContext dataContext;

        public BaseController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
    }
}