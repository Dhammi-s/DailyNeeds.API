using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.DTOs.Inbound
{
    public class SeriesDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid? PractitionerId { get; set; }
        public string Status { get; set; }
        public string ServiceTypeId { get; set; }
        public decimal? BillRate { get; set; }
        public decimal? PayRate { get; set; }
        public Guid BillTypeId { get; set; }
        public Guid PayTypeId { get; set; }
        public string TimeZone { get; set; }
        public string WallClockStart { get; set; }
        public string WallClockEnd { get; set; }
        public string Notes { get; set; }
    }
}
