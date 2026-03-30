using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace ServicePro.Core.DTOs.outbound
{
    public class OfficeListDto
    {
        public Guid OfficeId { get; set; }
        public string OfficeName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public bool IsActive { get; set; }
    }
}
