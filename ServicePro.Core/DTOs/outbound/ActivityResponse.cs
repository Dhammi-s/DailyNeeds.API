using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.DTOs.outbound
{
    public class ActivityResponse
    {
        public Guid ActivityId { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<string> Days { get; set; }
    }
}
