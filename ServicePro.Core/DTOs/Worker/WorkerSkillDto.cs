using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.DTOs.Worker
{
    public class WorkerSkillDto
    {
        public Guid ServiceId { get; set; }

        public string ServiceName { get; set; } = string.Empty;

        public int ExperienceYears { get; set; }
    }
}
