using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.Entities
{
    public class WorkerProfile
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string? ProfileImageBase64 { get; set; }

        public string? Bio { get; set; }

        public decimal HourlyRate { get; set; }

        public int ExperienceYears { get; set; }

        public string? ServiceArea { get; set; }

        public bool IsAvailable { get; set; } = true;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public User User { get; set; } = null!;
    }
}
