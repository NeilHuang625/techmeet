using techmeet.Models;

namespace techmeet.Repositories{
    public interface IEventRepository{
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event?> GetEventByIdAsync(int id);
        Task AddEventAsync(Event evt, IFormFile imageFile);
        Task UpdateEventAsync(Event evt, IFormFile imageFile);
        Task DeleteEventAsync(int id);
    }
}