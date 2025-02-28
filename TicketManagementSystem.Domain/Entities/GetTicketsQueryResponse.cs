using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystem.Domain.Entities
{
    public class GetTicketsQueryResponse
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public DateTime CreationDate { get; set; }
        public string Status { get; set; }
        public string Color { get; set; } // NEW
    }
}
