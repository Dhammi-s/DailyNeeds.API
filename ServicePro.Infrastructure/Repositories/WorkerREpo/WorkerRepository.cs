using Dapper;
using Microsoft.Data.SqlClient;
using ServicePro.Core.DTOs.Worker;
using ServicePro.Core.Interfaces.Databaseinterface;
using ServicePro.Core.Interfaces.IworkerRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServicePro.Infrastructure.Repositories.WorkerREpo
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public WorkerRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<WorkerProfileResponseDto?> GetWorkerProfileAsync(Guid workerId)
        {
            using var connection = _connectionFactory.CreateConnection();

            using var multi = await connection.QueryMultipleAsync(
                "sp_GetWorkerProfile",
                new { WorkerId = workerId },
                commandType: CommandType.StoredProcedure);

            var profile = await multi.ReadFirstOrDefaultAsync<WorkerProfileResponseDto>();

            if (profile == null)
                return null;

            profile.Skills =
                (await multi.ReadAsync<WorkerSkillDto>()).ToList();

            profile.Certificates =
                (await multi.ReadAsync<WorkerCertificateDto>()).ToList();

            profile.Availability =
                (await multi.ReadAsync<AvailabilityDto>()).ToList();

            return profile;
        }

        public async Task<Guid> CreateWorkerProfileAsync(WorkerProfileCreateRequestDto dto)
        {
            var newWorkerId = Guid.NewGuid();

            var skillsJson = JsonSerializer.Serialize(dto.Skills.Select(s => new
            {
                s.ServiceId,
                s.ExperienceYears
            }));

            var certificatesJson = JsonSerializer.Serialize(dto.Certificates.Select(c => new
            {
                c.CertificateName,
                c.CertificateFileBase64,
                c.ExpiryDate
            }));

            var availabilityJson = JsonSerializer.Serialize(dto.Availability.Select(a => new
            {
                a.AvailableDate,
                a.TimeSlotId,
                a.IsAvailable
            }));

            using SqlConnection db = _connectionFactory.CreateConnection();
            using SqlCommand cmd = new SqlCommand("sp_CreateWorkerProfile", db);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@WorkerId", newWorkerId);
            cmd.Parameters.AddWithValue("@UserId", dto.UserId);
            cmd.Parameters.AddWithValue("@ProfileImageBase64", (object?)dto.ProfileImageBase64 ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Bio", (object?)dto.Bio ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@HourlyRate", dto.HourlyRate);
            cmd.Parameters.AddWithValue("@ExperienceYears", dto.ExperienceYears);
            cmd.Parameters.AddWithValue("@ServiceArea", (object?)dto.ServiceArea ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@SkillsJson", skillsJson);
            cmd.Parameters.AddWithValue("@CertificatesJson", certificatesJson);
            cmd.Parameters.AddWithValue("@AvailabilityJson", availabilityJson);

            await db.OpenAsync();
            await cmd.ExecuteNonQueryAsync();

            return newWorkerId;
        }
    }
}
