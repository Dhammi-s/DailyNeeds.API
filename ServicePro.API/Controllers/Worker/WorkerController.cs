using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicePro.Core.DTOs.Worker;
using ServicePro.Core.Interfaces.workerinterfaces;

namespace ServicePro.API.Controllers.Worker
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpGet("{workerId}")]
        public async Task<IActionResult> GetWorkerProfile(Guid workerId)
        {
            var result = await _workerService.GetWorkerProfileAsync(workerId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkerProfile([FromBody] WorkerProfileCreateRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newId = await _workerService.CreateWorkerProfileAsync(dto);

            return CreatedAtAction(nameof(GetWorkerProfile), new { workerId = newId }, new { WorkerId = newId });
        }
    }
}
