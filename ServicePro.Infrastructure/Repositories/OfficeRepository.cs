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
    public class OfficeRepository : IOfficeRepository
    {
        private readonly AppDbContext _context;

        public OfficeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<OfficeListDto>> GetOfficeList()
        {
            return await _context.Set<OfficeListDto>()
                .FromSqlRaw("EXEC sp_GetOfficeList")
                .ToListAsync();
        }
    }
}
