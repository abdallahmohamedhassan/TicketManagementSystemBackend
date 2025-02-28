using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Application.Commands;
using TicketManagementSystem.Domain.Entities;
using TicketManagementSystem.Infrastructure.Persistence;
using TicketManagementSystem.Infrastructure.Repositories;

namespace TicketManagementSystem.Application.Handlers
{
   
    public class CreateTicketHandler : IRequestHandler<CreateTicketCommand, Guid>
    {
        private readonly ITicketRepository _ticketRepository;

        public CreateTicketHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<Guid> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var ticket = new Ticket(request.PhoneNumber, request.Governorate, request.City, request.District);
                await _ticketRepository.AddAsync(ticket);

                return ticket.Id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
