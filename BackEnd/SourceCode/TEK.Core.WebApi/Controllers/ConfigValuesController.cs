using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TEK.Core.Entity;
using TEK.Core.ResourceAccess.EF;

namespace TEK.Core.WebApi.Controllers
{
	[Route("api/ConfigValues")]
	[Produces("application/json")]    
    public class ConfigValuesController : BaseController
    {
        public ConfigValuesController(DataContext context) : base(context) { }

        // GET: api/ConfigValues
        [HttpGet]
        public async Task<IActionResult> GetConfigValues()
        {
            var result = await this.dataContext.ConfigValues.OrderBy(x => x.Name).ToListAsync();

			return Ok(result);
		}

        // GET: api/ConfigValues/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConfigValue([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var configValue = await this.dataContext.ConfigValues.SingleOrDefaultAsync(m => m.Id == id);

            if (configValue == null)
            {
                return NotFound();
            }

            return Ok(configValue);
        }

        // PUT: api/ConfigValues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfigValue([FromRoute] int id, [FromBody] ConfigValue configValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != configValue.Id)
            {
                return BadRequest();
            }

            this.dataContext.Entry(configValue).State = EntityState.Modified;

            try
            {
                await this.dataContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigValueExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ConfigValues
        [HttpPost]
        public async Task<IActionResult> PostConfigValue([FromBody] ConfigValue configValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.dataContext.ConfigValues.Add(configValue);
            await this.dataContext.SaveChangesAsync();

            return CreatedAtAction("GetConfigValue", new { id = configValue.Id }, configValue);
        }

        // DELETE: api/ConfigValues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfigValue([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var configValue = await this.dataContext.ConfigValues.SingleOrDefaultAsync(m => m.Id == id);

            if (configValue == null)
            {
                return NotFound();
            }

            this.dataContext.ConfigValues.Remove(configValue);
            await this.dataContext.SaveChangesAsync();

            return Ok(configValue);
        }

        private bool ConfigValueExists(int id)
        {
            return this.dataContext.ConfigValues.Any(e => e.Id == id);
        }
    }
}