using DataService.DBModels;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;

namespace BRICS_API_NEO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HDFCController : ControllerBase
    {


        [HttpPost("hdfcalertNotification")]
        public IActionResult hdfcalertNotification()
        {
            Icicilog _log = new Icicilog();
            try
            {
                var reader = new StreamReader(Request.Body);
                var request = reader.ReadToEndAsync().Result;
                _log.RequestId = Guid.NewGuid().ToString();
                _log.Sourceapi = "hdfcInstaAlert";
                _log.Encryptedrequest = request;
                StaticClass.Log(_log);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
