using Microsoft.AspNetCore.Mvc;
using SuperTool.Core.Models;

namespace SuperTool.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigurationsController : ControllerBase
    {
        private readonly ILogger<ConfigurationsController> _logger;

        public ConfigurationsController(ILogger<ConfigurationsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetConfiguration")]
        public IEnumerable<Configuration> Get()
        {
            var config = new Configuration() { Name = "Test" };

            return [config];
        }
    }
}
