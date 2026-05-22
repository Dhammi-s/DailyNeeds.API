using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.Entities
{
    public class WorkerSkill
    {
        public Guid Id { get; set; }

        public Guid WorkerId { get; set; }

        public Guid ServiceId { get; set; }

        public int ExperienceYears { get; set; }

        public bool IsActive { get; set; }

        public bool IsArchived { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
