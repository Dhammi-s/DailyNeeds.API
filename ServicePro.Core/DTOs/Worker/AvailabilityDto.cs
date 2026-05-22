using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.DTOs.Worker
{
    public class AvailabilityDto
    {
        public Guid Id { get; set; }

        public DateTime AvailableDate { get; set; }

        public Guid TimeSlotId { get; set; }

        public bool IsAvailable { get; set; }
    }
}
