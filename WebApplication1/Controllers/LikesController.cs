using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Models.ViewModels;
using WebApplication1.Data.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        public LikesService _likesService;


        public LikesController(LikesService likeService)
        {
            _likesService = likeService;
        }
        [HttpPost("add-like")]
        public IActionResult AddLike([FromBody] LikeVM like)//[FromBody] from body of teh request
        {
            _likesService.AddLike(like);
            return Ok();
        }

        [HttpGet("get-all-likes")]
        public IActionResult GetAllLikes()
        {
            var allLike = _likesService.GetAllLikes();
            return Ok(allLike);
        }


        [HttpGet("get-like-by-id/{id}")]
        public IActionResult GetlikeById(int id)
        {
            var post = _likesService.GeLikeById(id);
            return Ok(post);
        }


        [HttpDelete("delete-like-by-id/{id}")]
        public IActionResult DeleteLiById(int id)
        {
            _likesService.DeleteLikeById(id);
            return Ok();
        }
    }
}
