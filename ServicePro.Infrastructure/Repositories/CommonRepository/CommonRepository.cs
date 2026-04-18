using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ServicePro.Core.DTOs.Inbound;
using ServicePro.Core.Interfaces.CommonRepositoryInterfaces;
using System;
using System.Data;
using System.Threading.Tasks;

namespace ServicePro.Infrastructure.Repositories.CommonRepository
{
    public class CommonRepository : ICommonRepository
    {
        private readonly IConfiguration _config;

        public CommonRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<CategoriesInboundDto> CreateCategories(CategoriesInboundDto dto)
        {
            var newId = Guid.NewGuid();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("Service")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Category_Add", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Action", "INSERT");
                    cmd.Parameters.AddWithValue("@CategoryId", newId);
                    cmd.Parameters.AddWithValue("@Name", dto.Name);
                    cmd.Parameters.AddWithValue("@Icon", dto.Icon ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", dto.IsActive);
                    cmd.Parameters.AddWithValue("@IsArchived", dto.IsArchived);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return dto;
        }
    }
}