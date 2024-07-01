using Microsoft.AspNetCore.Mvc;
using techmeet.Models;
using techmeet.Repositories;

namespace techmeet.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase{
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository){
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Comment>> GetComments(){
            return await _commentRepository.GetAllCommentsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id){
            var comment = await _commentRepository.GetCommentByIdAsync(id);
            if(comment == null){
                return NotFound();
            }
            return comment;
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Comment comment){
            await _commentRepository.AddCommentAsync(comment);
            return CreatedAtAction(nameof(GetComment), new { id = comment.CommentId}, comment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, Comment comment){
            if(id != comment.CommentId){
                return BadRequest();
            }

            await _commentRepository.UpdateCommentAsync(comment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id){
            var comment = await _commentRepository.GetCommentByIdAsync(id);
            if(comment == null){
                return NotFound();
            }
            await _commentRepository.DeleteCommentAsync(id);
            return NoContent();
        }
    }
}