using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class SendMessageRepository : IMessageRepository
    {

           private readonly ApplicationDBContext _context;
        public SendMessageRepository (ApplicationDBContext context)
        {
            _context = context;
        }

        // private readonly DataContext _context;

        // public MessageRepository(DataContext context)
        // {
        //     _context = context;
        // }

        public async Task CreateAsync(SendMessage message)
        {
            await _context.SendMessage.AddAsync(message);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SendMessage>> GetByCurrentUserAsync(string userId)
        {
            return await _context.SendMessage
                .Where(m => m.ReceiverId == userId)
                .ToListAsync();
        }
 

        // Implement other methods as needed
    }
}
