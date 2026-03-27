using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("office-list")]
        public async Task<IActionResult> GetOfficeList()
        {
            var offices = await _officeService.GetOfficeList();

            return Ok(offices);
        }
    }
}
