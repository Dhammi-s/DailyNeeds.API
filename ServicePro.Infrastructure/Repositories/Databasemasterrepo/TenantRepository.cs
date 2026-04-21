using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ServicePro.Core.DTOs.Database;
using ServicePro.Core.Interfaces.Databaseinterface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Infrastructure.Repositories.Databasemasterrepo
{
    public class TenantRepository : ITenantRepository
    {
        private readonly IConfiguration _config;

        public TenantRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<AgencyDto> GetAgencyByDomainAsync(string domain)
        {
            string mainDb = _config.GetConnectionString("MainDb");

            using SqlConnection con = new SqlConnection(mainDb);
            using SqlCommand cmd = new SqlCommand("sp_GetAgencyByDomain", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Domain", domain);

            await con.OpenAsync();

            using var reader = await cmd.ExecuteReaderAsync();

            if (!reader.Read()) return null;

            return new AgencyDto
            {
                AgencyId = Convert.ToInt32(reader["AgencyId"]),
                DbServer = reader["DbServer"].ToString(),
                DbName = reader["DbName"].ToString(),
                DbUser = reader["DbUser"].ToString(),
                DbPassword = reader["DbPassword"].ToString(),
                ConnectionString = reader["ConnectionString"]?.ToString()
            };
        }
    }
}
