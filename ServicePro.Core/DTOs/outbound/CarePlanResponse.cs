using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.DTOs.outbound
{
    public class CarePlanResponse
    {
        public Guid CareLogId { get; set; }

        public Guid ClientId { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<ActivityResponse> Activities { get; set; }
    }
}
