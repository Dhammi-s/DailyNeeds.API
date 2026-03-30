using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Core.DTOs.outbound
{
    public class ClientListDto
    {

        public string Office { get; set; }
        public bool Status { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }

        public string PhonePrefix { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string AddressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public string EmergencyContactName { get; set; }
        public string Relationship { get; set; }

        public string ContactPhonePrefix { get; set; }
        public string ContactPhone { get; set; }
        public string ContactGender { get; set; }
        public string ContactAddress { get; set; }

        public string PreferredLanguage { get; set; }
        public bool IsPreferred { get; set; }

        public Guid? ClientId { get; set; }
        public bool IsClient { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsArchived { get; set; } = false;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
