using Microsoft.EntityFrameworkCore;
using techmeet.Models;

namespace techmeet.Data{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
    }
}
