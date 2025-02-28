using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Domain.Entities;
using TicketManagementSystem.Infrastructure.Persistence;

namespace TicketManagementSystem.Infrastructure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _context;

        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Ticket ticket)
        {
            try
            {
                await _context.Tickets.AddAsync(ticket);
                await SaveAsync();
            }
            catch (Exception ex) { throw; }
        }

        public async Task<Ticket?> GetByIdAsync(Guid id)
        {
            try
            {
                return await _context.Tickets.FindAsync(id);
            }
            catch (Exception ex) { throw; }

        }

        public async Task<List<Ticket>> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Tickets.ToListAsync(cancellationToken);
            }
            catch (Exception ex) { throw; }

        }
        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { throw; }

        }

    }
}
