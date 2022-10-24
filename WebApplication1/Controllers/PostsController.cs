using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Models.ViewModels;
using WebApplication1.Data.Services;

namespace WebApplication1.Controllers 
{
    [Route("api/[controller]")]
    [ApiController] //or MVC controller 

    public class PostsController : ControllerBase
    {
        public PostsService _postsService;

        public PostsController(PostsService postsService)
        {
            _postsService = postsService;
        }

        [HttpGet("get-all-posts")]
        public IActionResult GetAllPosts()
        {
            var allPosts = _postsService.GetAllPosts();
            return Ok(allPosts);
        }

      

        [HttpGet("get-post-by-id/{id}")]
        public IActionResult GetPostById(int id)
        {
            var post = _postsService.GetPostById(id);
            return Ok(post);
        }

        [HttpPost("add-post")]
        public IActionResult AddPost([FromBody]PostVM post)//[FromBody] from body of the request
        {
            _postsService.AddPost(post);
            return Ok();
        }

        [HttpPut("update-post-by-id/{id}")]

        public IActionResult UpdatePostById(int id,[FromBody]PostVM post)
        {
            var updatedPost = _postsService.UpdatePostById(id, post);

            return Ok(updatedPost);
        }
        [HttpDelete("delete-post-by-id/{id}")]
        public IActionResult DeletePostById( int id)
        {
            _postsService.DeletePostById(id);


            return Ok();
        }

    }
}
