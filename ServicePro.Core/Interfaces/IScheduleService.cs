using ServicePro.Core.DTOs.Inbound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.Interfaces
{
    public interface IScheduleService
    {
        Task<Guid> CreateSchedule(ScheduleRequestDto request);
    }
}
