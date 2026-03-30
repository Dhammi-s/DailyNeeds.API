using ServicePro.Core.DTOs.outbound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.Interfaces
{
    public interface IOfficeRepository
    {
        Task<List<OfficeListDto>> GetOfficeList();
    }
}
