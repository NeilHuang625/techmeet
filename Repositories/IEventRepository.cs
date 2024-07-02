using techmeet.Models;

namespace techmeet.Repositories{
    public interface IEventRepository{
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event?> GetEventByIdAsync(int id);
        Task AddEventAsync(Event evt);
        Task UpdateEventAsync(Event evt);
        Task DeleteEventAsync(int id);
    }
}