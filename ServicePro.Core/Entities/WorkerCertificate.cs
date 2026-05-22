using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.Entities
{
    public class WorkerCertificate
    {
        public Guid Id { get; set; }

        public Guid WorkerId { get; set; }

        public string CertificateName { get; set; } = string.Empty;

        public string? CertificateFileBase64 { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public User Worker { get; set; } = null!;
    }
}
