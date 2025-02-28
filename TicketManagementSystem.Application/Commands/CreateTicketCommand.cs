using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystem.Application.Commands
{
    public record CreateTicketCommand([Required(ErrorMessage = "Phone number is required")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be exactly 11 digits")]
   string PhoneNumber, [Required(ErrorMessage = "Governorate is required")]
    [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Governorate can only contain letters")]
    string Governorate, [Required(ErrorMessage = "City is required")]
    [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "City can only contain letters")]
    string City, [Required(ErrorMessage = "District is required")]
    [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "District can only contain letters")]
    string District) : IRequest<Guid>;

}
