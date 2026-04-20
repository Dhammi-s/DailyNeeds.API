using Microsoft.AspNetCore.Http;
using ServicePro.Core.DTOs.Inbound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.Interfaces
{
    public interface IFileUpload
    {
        Task<bool> UploadFileAsync(FileUploadRequestDTO file);
    }
}
