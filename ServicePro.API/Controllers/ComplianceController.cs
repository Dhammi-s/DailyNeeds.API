using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicePro.Core.DTOs.Inbound;
using ServicePro.Core.Interfaces;
using ServicePro.Services;

namespace ServicePro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplianceController : ControllerBase
    {
        private readonly IComplianceService _service;

        public ComplianceController(IComplianceService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddCompliance([FromBody] ComplianceRequest request)
        {
            await _service.AddComplianceAsync(request);

            return Ok(new { message = "Compliance added successfully" });
        }
        [HttpGet("compliances/{clientId}")]
        public async Task<IActionResult> GetCompliances(Guid clientId)
        {
            var result = await _service.GetCompliancesByClientId(clientId);

            return Ok(result);
        }
        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadComplianceFile(Guid id)
        {
            var compliance = await _service.GetComplianceFileById(id);

            if (compliance == null || compliance.FileData == null)
                return NotFound();

            return File(
                compliance.FileData,
                compliance.FileType,
                compliance.FileName
            );
        }
    }
}
