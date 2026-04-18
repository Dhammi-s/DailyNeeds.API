using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.Entities
{
    public class Categories
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public bool IsActive { get; set; }

        public bool IsArchived { get; set; }

        public DateTime CreatedAt  { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
