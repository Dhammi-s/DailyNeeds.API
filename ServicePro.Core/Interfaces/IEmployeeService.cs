
using ServicePro.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.Interfaces
{
    public interface IEmployeeService
    {
        //testcomments
        Task<List<EmployeeResponseDto>> GetAllEmployeesAsync();

    }
}
