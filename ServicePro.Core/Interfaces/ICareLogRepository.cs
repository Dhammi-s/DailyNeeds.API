using ServicePro.Core.DTOs.Inbound;
using ServicePro.Core.DTOs.outbound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.Interfaces
{
    public interface ICareLogRepository
    {
        Task AddCareLogAsync(CareLogRequest request);

        Task<List<CarePlanResponse>> GetCarePlanByClientId(Guid clientId);

    }
}
