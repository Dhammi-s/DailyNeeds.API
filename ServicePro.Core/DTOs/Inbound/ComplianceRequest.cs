using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.DTOs.Inbound
{
    public class ComplianceRequest
    {
        public Guid ClientId { get; set; }

        public string ComplianceType { get; set; }

        public DateTime OriginDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string LicenseNo { get; set; }

        public string Notes { get; set; }

        public string Status { get; set; }
    }
}
