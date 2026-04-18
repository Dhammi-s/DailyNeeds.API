using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicePro.Core.DTOs.Inbound;
using ServicePro.Core.Interfaces.CommonRepositoryInterfaces;

namespace ServicePro.API.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommonService _commonService;

        public CommonController(ICommonService commonService)   
        {
            _commonService = commonService;
        }

        [HttpPost("add-categories")]
        public async Task<IActionResult> CreateCategories([FromBody] CategoriesInboundDto dto)
        {
            var result = await _commonService.CreateCategories(dto);
            return Ok(result);
        }
    }
}
