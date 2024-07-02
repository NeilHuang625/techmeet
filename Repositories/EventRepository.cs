using Microsoft.EntityFrameworkCore;
using techmeet.Data;
using techmeet.Models;

namespace techmeet.Repositories{
    public class EventRepository : IEventRepository{
        private readonly ApplicationDbContext _context;

        public EventRepository(ApplicationDbContext context){
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync(){
            return await _context.Events.Include(e=>e.User).ToListAsync();
        }

        public async Task<Event?> GetEventByIdAsync(int id){
            return await _context.Events.Include(e=>e.User).FirstOrDefaultAsync(e=>e.EventId == id);
        }

        public async Task AddEventAsync(Event evt){
            await _context.Events.AddAsync(evt);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEventAsync(Event evt){
            _context.Events.Update(evt);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(int id){
            var evt = await _context.Events.FindAsync(id);
            if(evt != null){
                _context.Events.Remove(evt);
                await _context.SaveChangesAsync();
            }
        }
    }
}