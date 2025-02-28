using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystem.Domain.Entities
{
    public class Ticket
    {
        public Guid Id { get; private set; }
        public DateTime CreationDate { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Governorate { get; private set; }
        public string City { get; private set; }
        public string District { get; private set; }
        public bool IsHandled { get; private set; }

        public Ticket(string phoneNumber, string governorate, string city, string district)
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
            PhoneNumber = phoneNumber;
            Governorate = governorate;
            City = city;
            District = district;
            IsHandled = false;
        }

        public void MarkAsHandled()
        {
            IsHandled = true;
        }
        public string GetColor()
        {
            var ageMinutes = (DateTime.Now - CreationDate).TotalMinutes;
            if(IsHandled==true)
            {
                return "white";
            }
            return ageMinutes switch
            {
                <= 1 => "Yellow",
                <= 3 => "Green",
                <= 4 => "Blue",
                _ => "Red"
            };
        }
    }
}
