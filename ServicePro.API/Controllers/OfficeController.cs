using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicePro.Core.DTOs.Inbound;
using ServicePro.Core.Interfaces;

namespace ServicePro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService _officeService;

        public OfficeController(IOfficeService officeService)
        {
            _officeService = officeService;
        }
        [HttpPost]
        public async Task<IActionResult> AddOffice(AddOfficeRequest request)
        {
            await _officeService.AddOffice(request);

            return Ok("Office Created Successfully");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("office-list")]
        public async Task<IActionResult> GetOfficeList()
        {
            var offices = await _officeService.GetOfficeList();

            return Ok(offices);
        }
    }
}
