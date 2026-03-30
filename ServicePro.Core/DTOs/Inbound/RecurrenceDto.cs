using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.DTOs.Inbound
{
    public class RecurrenceDto
    {
        public string Type { get; set; }               // ONCE / DAILY / WEEKLY
        public int Interval { get; set; }              // Every 1 / 2 / etc
        public int MonthlyDayOfMonth { get; set; }
        public DateTime? RepeatUntil { get; set; }
    }
}
