using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Domain.Entities;

namespace TicketManagementSystem.Infrastructure.Repositories
{
    public interface ITicketRepository
    {
        Task AddAsync(Ticket ticket);
        Task<Ticket?> GetByIdAsync(Guid id);
        Task<List<Ticket>> GetAllAsync(CancellationToken cancellationToken);
        Task SaveAsync();

    }
}
