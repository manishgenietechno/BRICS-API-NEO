using BRICS_API_NEO.Services.Interface;
using Microsoft.AspNetCore.Mvc;


namespace BRICS_API_NEO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ICICIController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;

        public ICICIController(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }

        [HttpGet("Testing")]
        public string Testing()
        {
            return "This is testing api";
        }

        [HttpPost("icicialertNotification")]
        public IActionResult icicialertNotification()
        {
            try
            {
                var reader = new StreamReader(Request.Body);
                var request = reader.ReadToEndAsync().Result;
                if (!string.IsNullOrEmpty(request))
                {
                    var alertService = _serviceProvider.GetRequiredService<IIciciInterface>();
                    return Ok(alertService.alertNotification(request));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
