using ServicePro.Core.DTOs.Inbound;
using ServicePro.Core.Interfaces.CommonRepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Services.CommonService
{
    public class CommonService: ICommonService
    {
        public readonly ICommonRepository _repository;
        public CommonService(ICommonRepository repository)
        {
            _repository = repository;
        }
        public async Task<CategoriesInboundDto> CreateCategories(CategoriesInboundDto dto)
        {
            return await _repository.CreateCategories(dto);
        }
    }
}
