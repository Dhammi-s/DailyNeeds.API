using ServicePro.Core.DTOs.Inbound;
using ServicePro.Core.Entities;
using ServicePro.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Services
{
    public class ComplianceService : IComplianceService
    {
        private readonly IComplianceRepository _repository;

        public ComplianceService(IComplianceRepository repository)
        {
            _repository = repository;
        }

        public async Task AddComplianceAsync(ComplianceRequest request)
        {
            await _repository.AddComplianceAsync(request);
        }
        public async Task<List<ComplianceSpResult>> GetCompliancesByClientId(Guid clientId)
        {
            return await _repository.GetCompliancesByClientId(clientId);
        }
    }
}
