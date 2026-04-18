using ServicePro.Core.DTOs.Inbound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.Interfaces.CommonRepositoryInterfaces
{
    public interface ICommonService
    {
        Task<CategoriesInboundDto> CreateCategories(CategoriesInboundDto dto);

    }
}
