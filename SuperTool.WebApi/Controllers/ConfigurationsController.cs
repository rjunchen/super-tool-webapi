using Microsoft.AspNetCore.Mvc;
using SuperTool.Core.Models;
using SuperTool.Infrastructure.Service;

namespace SuperTool.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigurationsController : ControllerBase
    {
        private readonly ILogger<ConfigurationsController> _logger;
        private readonly ConfigurationService _configurationService;

        public ConfigurationsController(ILogger<ConfigurationsController> logger, ConfigurationService configurationService)
        {
            _logger = logger;
            _configurationService = configurationService;
        }

        [HttpGet]
        public async Task<List<Configuration>> Get() =>
            await _configurationService.GetAsync();


        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Configuration>> Get(string id)
        {
            var book = await _configurationService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Configuration newConfiguration)
        {
            await _configurationService.CreateAsync(newConfiguration);

            return CreatedAtAction(nameof(Get), new { id = newConfiguration.Id }, newConfiguration);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Configuration updatedConfiguration)
        {
            var configuration = await _configurationService.GetAsync(id);

            if (configuration is null)
            {
                return NotFound();
            }

            updatedConfiguration.Id = configuration.Id;

            await _configurationService.UpdateAsync(id, updatedConfiguration);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var configuration = await _configurationService.GetAsync(id);

            if (configuration is null)
            {
                return NotFound();
            }

            await _configurationService.RemoveAsync(id);

            return NoContent();
        }
    }
}
