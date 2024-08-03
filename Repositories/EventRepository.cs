using Microsoft.EntityFrameworkCore;
using techmeet.Data;
using techmeet.Models;

namespace techmeet.Repositories{
    public class EventRepository : IEventRepository{
        private readonly EventContext _context;

        public EventRepository(EventContext context){
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync(){
            return await _context.Events.ToListAsync();
        }

        public async Task<Event?> GetEventByIdAsync(int id){
            return await _context.Events.FirstOrDefaultAsync(e=>e.EventId == id);
        }

        public async Task AddEventAsync(Event evt, IFormFile imageFile){
            if(imageFile != null){
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads", imageFile.FileName);
                using(var fileStream = new FileStream(filePath, FileMode.Create)){
                    await imageFile.CopyToAsync(fileStream);
                }
                evt.ImagePath = filePath;
            }
            _context.Events.Add(evt);
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