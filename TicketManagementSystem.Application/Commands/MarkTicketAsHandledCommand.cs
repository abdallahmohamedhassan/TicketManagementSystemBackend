using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystem.Application.Commands
{
    public class MarkTicketAsHandledCommand : IRequest<bool>
    {
        public Guid TicketId { get; set; }
    }
}
