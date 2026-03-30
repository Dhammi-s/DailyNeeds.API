using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServicePro.Core.DTOs.Inbound;
using ServicePro.Core.DTOs.outbound;
using ServicePro.Core.Interfaces;
using ServicePro.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Infrastructure.Repositories
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;


        public OfficeRepository(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }

        public async Task<List<OfficeListDto>> GetOfficeList()
        {
            return await _context.Set<OfficeListDto>()
                .FromSqlRaw("EXEC sp_GetOfficeList")
                .ToListAsync();
        }
        public async Task AddOffice(AddOfficeRequest request)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("Service")))
            {
                using (SqlCommand cmd = new SqlCommand("AddOffice", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@OfficeName", request.officeName);
                    cmd.Parameters.AddWithValue("@OfficeInvoiceName", request.businessLegalName);
                    cmd.Parameters.AddWithValue("@ContactName", request.adminUserName);
                    cmd.Parameters.AddWithValue("@Email", request.adminEmail);
                    cmd.Parameters.AddWithValue("@City", request.officeCity);
                    cmd.Parameters.AddWithValue("@State", request.officeState);
                    cmd.Parameters.AddWithValue("@PostalCode", request.officeZipCode);
                    cmd.Parameters.AddWithValue("@Country", request.officeCountry);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
