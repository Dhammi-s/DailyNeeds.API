using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicePro.Core.Interfaces;
using ServicePro.Infrastructure.Data;
using ServicePro.Infrastructure.Repositories;
using ServicePro.Services;

namespace ServicePro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientsController(IClientService service)
        {
            _service = service;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] Client model)
        {
            var result = await _service.CreateClient(model);

            return Ok(new
            {
                message = "Client created successfully",
                data = result
            });
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("get-all-clients")]
        public async Task<IActionResult> GetAllClients()
        {
            var result = await _service.GetAllClients();

            return Ok(result);
        }
        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> GetClientByClientId(Guid clientId)
        {
            var result = await _service.GetClientByClientId(clientId);

            if (result == null)
            {
                return NotFound(new { message = "Client not found" });
            }

            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{clientId}")]
        public async Task<IActionResult> UpdateClient(Guid clientId, [FromBody] Client client)
        {
            await _service.UpdateClient(clientId, client);

            return Ok(new
            {
                message = "Client updated successfully"
            });
        }
    }
}
