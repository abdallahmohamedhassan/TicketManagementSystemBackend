using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Application.Queries;
using TicketManagementSystem.Domain.Entities;
using TicketManagementSystem.Infrastructure.Persistence;
using TicketManagementSystem.Infrastructure.Repositories;

namespace TicketManagementSystem.Application.Handlers
{
    public class GetTicketsHandler : IRequestHandler<GetTicketsQuery, List<GetTicketsQueryResponse>>
    {
        private readonly ITicketRepository _ticketRepository;

        public GetTicketsHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }


        public async Task<List<GetTicketsQueryResponse>> Handle(GetTicketsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tickets = await _ticketRepository.GetAllAsync(cancellationToken);

                return tickets.Select(t => new GetTicketsQueryResponse
                {
                    Id = t.Id,
                    PhoneNumber = t.PhoneNumber,
                    Governorate = t.Governorate,
                    City = t.City,
                    District = t.District,
                    CreationDate = t.CreationDate,
                    Status = t.IsHandled ? "Handled" : "Pending",
                    Color = t.GetColor()
                }).ToList();
            }
            catch (Exception ex) {
                throw;
            }
        }



    }
}
