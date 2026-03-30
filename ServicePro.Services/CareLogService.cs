using ServicePro.Core.DTOs.Inbound;
using ServicePro.Core.DTOs.outbound;
using ServicePro.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Services
{
    public class CareLogService : ICareLogService
    {
        private readonly ICareLogRepository _repo;

        public CareLogService(ICareLogRepository repo)
        {
            _repo = repo;
        }

        public async Task CreateCareLogAsync(CareLogRequest request)
        {
            await _repo.AddCareLogAsync(request);
        }
        public async Task<List<CarePlanResponse>> GetCarePlanByClientId(Guid clientId)
        {
            return await _repo.GetCarePlanByClientId(clientId);
        }
    }
}
