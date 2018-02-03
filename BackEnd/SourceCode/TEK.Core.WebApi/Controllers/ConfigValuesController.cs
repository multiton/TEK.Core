using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TEK.Core.Entity;
using TEK.Core.ResourceAccess.EF;

namespace TEK.Core.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/ConfigValues")]
    public class ConfigValuesController : Controller
    {
        private readonly DataContext context;

        public ConfigValuesController(DataContext context) { this.context = context; }

        // GET: api/ConfigValues
        [HttpGet]
        public IEnumerable<ConfigValue> GetConfigValues()
        {
            return context.ConfigValues;
        }

        // GET: api/ConfigValues/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConfigValue([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var configValue = await context.ConfigValues.SingleOrDefaultAsync(m => m.Id == id);

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

            context.Entry(configValue).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
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

            context.ConfigValues.Add(configValue);
            await context.SaveChangesAsync();

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

            var configValue = await context.ConfigValues.SingleOrDefaultAsync(m => m.Id == id);

            if (configValue == null)
            {
                return NotFound();
            }

            context.ConfigValues.Remove(configValue);
            await context.SaveChangesAsync();

            return Ok(configValue);
        }

        private bool ConfigValueExists(int id)
        {
            return context.ConfigValues.Any(e => e.Id == id);
        }
    }
}