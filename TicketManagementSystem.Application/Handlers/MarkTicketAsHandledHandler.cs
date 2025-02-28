using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Application.Commands;
using TicketManagementSystem.Infrastructure.Persistence;
using TicketManagementSystem.Infrastructure.Repositories;

namespace TicketManagementSystem.Application.Handlers
{
    public class MarkTicketAsHandledHandler : IRequestHandler<MarkTicketAsHandledCommand, bool>
    {
        private readonly ITicketRepository _ticketRepository;

        public MarkTicketAsHandledHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<bool> Handle(MarkTicketAsHandledCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var ticket = await _ticketRepository.GetByIdAsync(request.TicketId);

                if (ticket == null) return false;

                ticket.MarkAsHandled();
                await _ticketRepository.SaveAsync();
                return true;
            }
            catch (Exception ex) { throw; }
        }
    }
}
