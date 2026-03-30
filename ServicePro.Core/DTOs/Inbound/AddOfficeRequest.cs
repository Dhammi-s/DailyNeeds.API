using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.DTOs.Inbound
{
    public class AddOfficeRequest
    {
        public string officeName { get; set; }
        public string businessLegalName { get; set; }
        public string officeCountry { get; set; }
        public string officeState { get; set; }
        public string officeCity { get; set; }
        public string officeZipCode { get; set; }
        public string adminUserName { get; set; }
        public string adminEmail { get; set; }
    }
}
