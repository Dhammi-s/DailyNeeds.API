using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.DTOs.Worker
{

    public class WorkerProfileResponseDto
    {
        public Guid UserId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string? ProfileImageBase64 { get; set; }

        public string? Bio { get; set; }

        public decimal HourlyRate { get; set; }

        public int ExperienceYears { get; set; }

        public string? ServiceArea { get; set; }

        public List<WorkerSkillDto> Skills { get; set; } = [];

        public List<WorkerCertificateDto> Certificates { get; set; } = [];
        public List<AvailabilityDto> Availability { get; set; } = [];
    }
}
