using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ServicePro.Core.DTOs.outbound;
using ServicePro.Core.Interfaces;
using ServicePro.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Client> CreateClient(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }
        public async Task<List<ClientListDto>> GetAllClients()
        {
            return await _context.Clients
                .Select(c => new ClientListDto
                {
                    Office = c.Office,
                    Status = c.Status,
                    FirstName = c.FirstName,
                    MiddleName = c.MiddleName,
                    LastName = c.LastName,
                    Gender = c.Gender,
                    BirthDate = c.BirthDate,
                    PhonePrefix = c.PhonePrefix,
                    Phone = c.Phone,
                    Email = c.Email,
                    AddressLine = c.AddressLine,
                    City = c.City,
                    State = c.State,
                    PostalCode = c.PostalCode,
                    Country = c.Country,
                    EmergencyContactName = c.EmergencyContactName,
                    Relationship = c.Relationship,
                    ContactPhonePrefix = c.ContactPhonePrefix,
                    ContactPhone = c.ContactPhone,
                    ContactGender = c.ContactGender,
                    ContactAddress = c.ContactAddress,
                    PreferredLanguage = c.PreferredLanguage,
                    IsPreferred = c.IsPreferred,
                    ClientId = c.ClientId,
                    IsClient = c.IsClient,
                    IsActive = c.IsActive,
                    IsArchived = c.IsArchived,
                    CreatedDate = c.CreatedDate,
                    UpdatedDate = c.UpdatedDate
                })
                .ToListAsync();
        }
        public async Task<ClientListDto?> GetClientByClientId(Guid clientId)
        {
            return await _context.Clients
                .Where(c => c.ClientId == clientId && !c.IsArchived)
                .Select(c => new ClientListDto
                {
                    Office = c.Office,
                    Status = c.Status,
                    FirstName = c.FirstName,
                    MiddleName = c.MiddleName,
                    LastName = c.LastName,
                    Gender = c.Gender,
                    BirthDate = c.BirthDate,
                    PhonePrefix = c.PhonePrefix,
                    Phone = c.Phone,
                    Email = c.Email,
                    AddressLine = c.AddressLine,
                    City = c.City,
                    State = c.State,
                    PostalCode = c.PostalCode,
                    Country = c.Country,
                    EmergencyContactName = c.EmergencyContactName,
                    Relationship = c.Relationship,
                    ContactPhonePrefix = c.ContactPhonePrefix,
                    ContactPhone = c.ContactPhone,
                    ContactGender = c.ContactGender,
                    ContactAddress = c.ContactAddress,
                    PreferredLanguage = c.PreferredLanguage,
                    IsPreferred = c.IsPreferred,
                    ClientId = c.ClientId,
                    IsClient = c.IsClient,
                    IsActive = c.IsActive,
                    IsArchived = c.IsArchived,
                    CreatedDate = c.CreatedDate,
                    UpdatedDate = c.UpdatedDate
                })
                .FirstOrDefaultAsync();
        }
        public async Task UpdateClient(Guid clientId, Client client)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateClient @ClientId, @Office, @Status, @FirstName, @MiddleName, @LastName, @Gender, @BirthDate, @PhonePrefix, @Phone, @Email, @AddressLine, @City, @State, @PostalCode, @Country, @EmergencyContactName, @Relationship, @ContactPhonePrefix, @ContactPhone, @ContactGender, @ContactAddress, @PreferredLanguage, @IsPreferred, @IsClient",

                new SqlParameter("@ClientId", clientId),
                new SqlParameter("@Office", client.Office ?? (object)DBNull.Value),
                new SqlParameter("@Status", client.Status),

                new SqlParameter("@FirstName", client.FirstName ?? (object)DBNull.Value),
                new SqlParameter("@MiddleName", client.MiddleName ?? (object)DBNull.Value),
                new SqlParameter("@LastName", client.LastName ?? (object)DBNull.Value),

                new SqlParameter("@Gender", client.Gender ?? (object)DBNull.Value),
                new SqlParameter("@BirthDate", client.BirthDate ?? (object)DBNull.Value),

                new SqlParameter("@PhonePrefix", client.PhonePrefix ?? (object)DBNull.Value),
                new SqlParameter("@Phone", client.Phone ?? (object)DBNull.Value),
                new SqlParameter("@Email", client.Email ?? (object)DBNull.Value),

                new SqlParameter("@AddressLine", client.AddressLine ?? (object)DBNull.Value),
                new SqlParameter("@City", client.City ?? (object)DBNull.Value),
                new SqlParameter("@State", client.State ?? (object)DBNull.Value),
                new SqlParameter("@PostalCode", client.PostalCode ?? (object)DBNull.Value),
                new SqlParameter("@Country", client.Country ?? (object)DBNull.Value),

                new SqlParameter("@EmergencyContactName", client.EmergencyContactName ?? (object)DBNull.Value),
                new SqlParameter("@Relationship", client.Relationship ?? (object)DBNull.Value),
                new SqlParameter("@ContactPhonePrefix", client.ContactPhonePrefix ?? (object)DBNull.Value),
                new SqlParameter("@ContactPhone", client.ContactPhone ?? (object)DBNull.Value),
                new SqlParameter("@ContactGender", client.ContactGender ?? (object)DBNull.Value),
                new SqlParameter("@ContactAddress", client.ContactAddress ?? (object)DBNull.Value),

                new SqlParameter("@PreferredLanguage", client.PreferredLanguage ?? (object)DBNull.Value),
                new SqlParameter("@IsPreferred", client.IsPreferred),

                new SqlParameter("@IsClient", client.IsClient)
            );
        }

    }
}
