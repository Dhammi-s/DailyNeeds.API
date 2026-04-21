using ServicePro.Core.DTOs.Database;
using ServicePro.Core.Interfaces.Databaseinterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Services.DatabasemasterService
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _repo;

        public TenantService(ITenantRepository repo)
        {
            _repo = repo;
        }

        public async Task<AgencyDto> GetAgencyAsync(string domain)
        {
            return await _repo.GetAgencyByDomainAsync(domain);
        }
    }
}
