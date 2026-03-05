using Microsoft.EntityFrameworkCore;
using ServicePro.Core.DTOs;
using ServicePro.Core.Interfaces;
using ServicePro.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly AppDbContext _context;
        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<EmployeeResponseDto>> GetAllEmployeesAsync()
        {
              var allemployees = await _context.Employees
                .AsNoTracking()
                .Select(e => new EmployeeResponseDto
                {
                    Employeeid = e.Employeeid,
                    Employeename = e.Employeename ?? "",
                    email = e.email ?? "",
                    phone_number = e.phone_number ?? "",
                    hire_date = e.hire_date,
                    job_title = e.job_title ?? "",
                    role = e.role ?? "",
                    isactive = e.isactive,
                    isarchived = e.isarchived,
                    created_at = e.created_at,
                    updated_at = e.updated_at,
                    employeeadress = e.employeeadress ?? "",
                    AdharcardNumber = e.AdharcardNumber ?? "",
                    Profilepic = e.Profilepic ?? ""
                })
                .ToListAsync();
             
                return allemployees;
                        }
                
                        }
          }
                
