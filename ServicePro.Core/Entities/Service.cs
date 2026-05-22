using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.Entities
{
    public class Service
    {
        public Guid ServiceId { get; set; }

        public Guid CategoryId { get; set; }

        public string ServiceName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal BasePrice { get; set; }

        public int Duration { get; set; }

        public bool IsActive { get; set; }

        public bool IsArchived { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
