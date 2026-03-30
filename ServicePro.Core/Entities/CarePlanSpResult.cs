using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.Entities
{
    public class CarePlanSpResult
    {
        public Guid CareLogId { get; set; }

        public Guid ClientId { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid ActivityId { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public DateTime ActivityStartDate { get; set; }

        public DateTime ActivityEndDate { get; set; }

        public string Days { get; set; }
    }
}
