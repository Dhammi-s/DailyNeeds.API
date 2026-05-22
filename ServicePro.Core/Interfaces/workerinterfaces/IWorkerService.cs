using ServicePro.Core.DTOs.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.Interfaces.workerinterfaces
{
    public interface IWorkerService
    {
        Task<WorkerProfileResponseDto?> GetWorkerProfileAsync(Guid workerId);
        Task<Guid> CreateWorkerProfileAsync(WorkerProfileCreateRequestDto dto);
    }
}
