using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicePro.Core.DTOs.Inbound;
using ServicePro.Core.Interfaces;

namespace ServicePro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUpload : ControllerBase
    {
        public readonly IFileUpload _FileUpload;
        public FileUpload(IFileUpload FileUpload)
        {
            _FileUpload = FileUpload;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromBody] FileUploadRequestDTO file)
        {
            if (file == null )
            {
                return BadRequest("No file uploaded.");
            }

            var result = await _FileUpload.UploadFileAsync(file);
            if (!result)
            {
                return StatusCode(500, "Error uploading file.");
            }

            return Ok("File uploaded successfully.");
        }
    }
}
