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
        public CommentsService _commentsService;

        public CommentsController(CommentsService commentsService)
        {
            _commentsService = commentsService;
        }


        [HttpPost("add-comment")]
        public IActionResult AddComment([FromBody]CommentVM comment)//[FromBody] from body of teh request
        {
            _commentsService.AddComment(comment);
            return Ok();
        }

        [HttpGet("get-all-comments-by-postid")]
        public IActionResult GetAllComments(int postId)
        {
            var allComments = _commentsService.GetAllComments(postId);
            return Ok(allComments);
        }


        [HttpGet("get-comment-by-id/{id}")]
        public IActionResult GetPostById(int id)
        {
            var post = _commentsService.GetCommentById(id);
            return Ok(post);
        }


        [HttpDelete("delete-comment-by-id/{id}")]
        public IActionResult DeleteCommentById(int id)
        {
            _commentsService.DeleteComentById(id);
            return Ok();
        }

        [HttpDelete ("delete-commenrts-by-postid/{postid}")]
        public IActionResult DeleteComentsByIds(int postId)
        {
            _commentsService.DeleteComentsByPostId(postId);
            return Ok();
        }
    }
}
