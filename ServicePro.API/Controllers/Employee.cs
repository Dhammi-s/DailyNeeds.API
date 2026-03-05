using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicePro.Core.Interfaces;

namespace ServicePro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employee : ControllerBase
    {
        private readonly IEmployeeService _service;
        public Employee(IEmployeeService service)
        {
            _service = service;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _service.GetAllEmployeesAsync();
            return Ok(data);
        }
    }
}