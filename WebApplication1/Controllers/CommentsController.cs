using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Models.ViewModels;
using WebApplication1.Data.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CommentsController : ControllerBase
    {
        public CommentsService _commentService;

        public CommentsController(CommentsService commentsService)
        {
            _commentService = commentsService;
        }


        [HttpPost("add-comment")]
        public IActionResult AddComment([FromBody]CommentVM comment)//[FromBody] from body of teh request
        {
            _commentService.AddComment(comment);
            return Ok();
        }

        [HttpGet("get-all-comments")]
        public IActionResult GetAllComments()
        {
            var allComments = _commentService.GetAllComments();
            return Ok(allComments);
        }


        [HttpGet("get-comment-by-id/{id}")]
        public IActionResult GetPostById(int id)
        {
            var post = _commentService.GetCommentById(id);
            return Ok(post);
        }


        [HttpDelete("delete-comment-by-id/{id}")]
        public IActionResult DeleteCommentById(int id)
        {
            _commentService.DeleteComentById(id);
            return Ok();
        }
    }
}
