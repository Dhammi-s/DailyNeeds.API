using ServicePro.Core.DTOs.outbound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> CreateClient(Client client);
        Task<List<ClientListDto>> GetAllClients();
        Task<ClientListDto?> GetClientByClientId(Guid clientId);
        Task UpdateClient(Guid clientId, Client client);

    }
}
