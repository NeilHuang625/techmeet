using Microsoft.EntityFrameworkCore;
using techmeet.Models;

namespace techmeet.Data{
    public class ApplicationDbContext : DbContext{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set;}
        public DbSet<Comment> Comments { get; set;}
    }
}