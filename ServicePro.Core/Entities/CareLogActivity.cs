using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.Entities
{
    public class CareLogActivity
    {
        [Key]
        public Guid ActivityId { get; set; }

        public Guid CareLogId { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Days { get; set; }
    }
}
