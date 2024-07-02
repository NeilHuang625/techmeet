using Microsoft.EntityFrameworkCore;
using techmeet.Data;
using techmeet.Models;

namespace techmeet.Repositories{
    public class CommentRepository : ICommentRepository{
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context){
            _context = context;
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsAsync(){
            return await _context.Comments.Include(c=>c.User).Include(c=>c.Event).ToListAsync();
        }

        public async Task<Comment?> GetCommentByIdAsync(int id){
            return await _context.Comments.Include(c=>c.User).Include(c=>c.Event).FirstOrDefaultAsync(c=>c.CommentId == id);
        }

        public async Task AddCommentAsync(Comment comment){
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCommentAsync(Comment comment){
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int id){
            var comment = await _context.Comments.FindAsync(id);
            if(comment != null){
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }
    }
}