using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.DTOs.Inbound
{
    public class ScheduleRequestDto
    {
        public Guid LocationId { get; set; }            // User select karega
        public Guid ClientId { get; set; }              // FK from frontend
        public string TimeZone { get; set; }
        public Guid FhirCarePlanId { get; set; }

        public RecurrenceDto Recurrence { get; set; }   // Recurrence info
        public List<SeriesDto> Series { get; set; }     // Multiple series
    }
}
