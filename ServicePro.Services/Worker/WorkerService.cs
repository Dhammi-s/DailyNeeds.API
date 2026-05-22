using ServicePro.Core.DTOs.Worker;
using ServicePro.Core.Interfaces.IworkerRepository;
using ServicePro.Core.Interfaces.workerinterfaces;
using System;
using System.Threading.Tasks;

namespace ServicePro.Services.Worker
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _repository;

        public WorkerService(IWorkerRepository repository)
        {
            _repository = repository;
        }

        public async Task<WorkerProfileResponseDto?> GetWorkerProfileAsync(Guid workerId)
        {
            return await _repository.GetWorkerProfileAsync(workerId);
        }

        public async Task<Guid> CreateWorkerProfileAsync(WorkerProfileCreateRequestDto dto)
        {
            return await _repository.CreateWorkerProfileAsync(dto);
        }
    }
}