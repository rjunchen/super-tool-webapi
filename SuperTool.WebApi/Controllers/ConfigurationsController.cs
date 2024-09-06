using Microsoft.AspNetCore.Mvc;
using SuperTool.Core.Models;

namespace SuperTool.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigurationsController : ControllerBase
    {
        private readonly ILogger<ConfigurationsController> _logger;

        public ConfigurationsController(ILogger<ConfigurationsController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public Configuration GetConfiguration()
        {
            var config = new Configuration() { Name = "Test" };

            return config;
        }

        [HttpPost()]
        public Configuration PostConfiguration()
        {
            var config = new Configuration() { Name = "Test" };

            return config;
        }
    }
}
