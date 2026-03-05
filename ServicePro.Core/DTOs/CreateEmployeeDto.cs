using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.DTOs
{
    public class CreateEmployeeDto
    {
        public string Employeename { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public DateTime hire_date { get; set; }   // FIXED
        public string job_title { get; set; }
        public string role { get; set; }
        public bool isactive { get; set; } = true;
        public bool isarchived { get; set; } = true;
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string employeeadress { get; set; }
        public string AdharcardNumber { get; set; }
        public IFormFile Profilepic { get; set; }
    }
}
