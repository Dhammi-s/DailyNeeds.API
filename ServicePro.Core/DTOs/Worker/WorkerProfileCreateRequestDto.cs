using System;
using System.Collections.Generic;

namespace ServicePro.Core.DTOs.Worker
{
    public class WorkerProfileCreateRequestDto
    {
        public Guid UserId { get; set; }

        public string? ProfileImageBase64 { get; set; }

        public string? Bio { get; set; }

        public decimal HourlyRate { get; set; }

        public int ExperienceYears { get; set; }

        public string? ServiceArea { get; set; }

        public List<WorkerSkillCreateDto> Skills { get; set; } = [];

        public List<WorkerCertificateCreateDto> Certificates { get; set; } = [];

        public List<AvailabilityCreateDto> Availability { get; set; } = [];
    }

    public class WorkerSkillCreateDto
    {
        public Guid ServiceId { get; set; }

        public int ExperienceYears { get; set; }
    }

    public class WorkerCertificateCreateDto
    {
        public string CertificateName { get; set; } = string.Empty;

        public string? CertificateFileBase64 { get; set; }

        public DateTime? ExpiryDate { get; set; }
    }

    public class AvailabilityCreateDto
    {
        public DateTime AvailableDate { get; set; }

        public Guid TimeSlotId { get; set; }

        public bool IsAvailable { get; set; }
    }
}
