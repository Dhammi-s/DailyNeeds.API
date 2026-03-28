using Microsoft.EntityFrameworkCore;
using ServicePro.Core.DTOs.Inbound;
using ServicePro.Core.Entities;
using ServicePro.Core.Interfaces;
using ServicePro.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Infrastructure.Repositories
{
    public class ComplianceRepository : IComplianceRepository
    {
        private readonly AppDbContext _context;

        public ComplianceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddComplianceAsync(ComplianceRequest request)
        {
            var compliance = new Compliance
            {
                ComplianceId = Guid.NewGuid(),
                ClientId = request.ClientId,
                ComplianceType = request.ComplianceType,
                OriginDate = request.OriginDate,
                ExpirationDate = request.ExpirationDate,
                LicenseNo = request.LicenseNo,
                Notes = request.Notes,
                Status = request.Status
            };

            _context.Compliances.Add(compliance);

            await _context.SaveChangesAsync();
        }
        public async Task<List<ComplianceSpResult>> GetCompliancesByClientId(Guid clientId)
        {
            var result = await _context.ComplianceSpResults
                .FromSqlRaw("EXEC sp_GetCompliancesByClientId @ClientId = {0}", clientId)
                .ToListAsync();

            return result;
        }
    }
}
