using ServicePro.Core.DTOs.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.Interfaces.Databaseinterface
{
    public interface ITenantRepository
    {
        Task<AgencyDto> GetAgencyByDomainAsync(string domain);
    }

    public interface ITenantService
    {
        Task<AgencyDto> GetAgencyAsync(string domain);
    }
}
