using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Domain.Entities;

namespace TicketManagementSystem.Application.Queries
{
    public class GetTicketsQuery : IRequest<List<GetTicketsQueryResponse>> { }
    
}
