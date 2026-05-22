using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.DTOs.Worker
{
    public class WorkerCertificateDto
    {
        public Guid Id { get; set; }

        public string CertificateName { get; set; } = string.Empty;

        public string? CertificateFileBase64 { get; set; }

        public DateTime? ExpiryDate { get; set; }
    }
}
