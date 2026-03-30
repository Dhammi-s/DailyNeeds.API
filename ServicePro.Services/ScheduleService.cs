using ServicePro.Core.DTOs.Inbound;
using ServicePro.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _repository;

        public ScheduleService(IScheduleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> CreateSchedule(ScheduleRequestDto request)
        {
            return await _repository.CreateSchedule(request);
        }
    }
}
