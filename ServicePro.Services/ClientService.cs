using ServicePro.Core.DTOs.outbound;
using ServicePro.Core.Interfaces;
using ServicePro.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Client> CreateClient(Client client)
        {
            client.CreatedDate = DateTime.Now;
            client.IsActive = true;
            client.IsArchived = false;

            return await _repository.CreateClient(client);
        }
        public async Task<List<ClientListDto>> GetAllClients()
        {
            return await _repository.GetAllClients();
        }
        public async Task<ClientListDto?> GetClientByClientId(Guid clientId)
        {
            return await _repository.GetClientByClientId(clientId);
        }
        public async Task UpdateClient(Guid clientId, Client client)
        {
            await _repository.UpdateClient(clientId, client);
        }

    }
}
