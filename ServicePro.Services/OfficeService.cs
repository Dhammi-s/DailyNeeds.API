using ServicePro.Core.DTOs.outbound;
using ServicePro.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepository _officeRepository;

        public OfficeService(IOfficeRepository officeRepository)
        {
            _officeRepository = officeRepository;
        }

        public async Task<List<OfficeListDto>> GetOfficeList()
        {
            return await _officeRepository.GetOfficeList();
        }
    }
}
