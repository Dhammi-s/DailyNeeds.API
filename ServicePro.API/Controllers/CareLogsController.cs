using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicePro.Core.DTOs.Inbound;
using ServicePro.Core.Interfaces;

namespace ServicePro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareLogsController : ControllerBase
    {
        private readonly ICareLogService _service;

        public CareLogsController(ICareLogService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCareLog([FromBody] CareLogRequest request)
        {
            await _service.CreateCareLogAsync(request);

            return Ok(new
            {
                message = "Care Log Created Successfully"
            });
        }
        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> GetCarePlanByClient(Guid clientId)
        {
            var data = await _service.GetCarePlanByClientId(clientId);

            return Ok(data);
        }
    }
}
