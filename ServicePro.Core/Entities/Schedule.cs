using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.Entities
{
    public class Schedule
    {
        public Guid ScheduleId { get; set; }

        public Guid ClientId { get; set; }

        public Guid LocationId { get; set; }

        public Guid CarePlanId { get; set; }

        public string TimeZone { get; set; }

        public string RecurrenceType { get; set; }

        public int Interval { get; set; }

        public int MonthlyDayOfMonth { get; set; }

        public DateTime? RepeatUntil { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        public bool IsArchived { get; set; }

        public List<ScheduleSeries> Series { get; set; }
    }
}
