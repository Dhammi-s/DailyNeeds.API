using ServicePro.Core.DTOs.Inbound;
using ServicePro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.Interfaces
{
    public interface IComplianceService
    {
        Task AddComplianceAsync(ComplianceRequest request);
        Task<List<ComplianceSpResult>> GetCompliancesByClientId(Guid clientId);
        Task<Compliance> GetComplianceFileById(Guid id);

    }
}
