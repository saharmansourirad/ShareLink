using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Models.ViewModels;
using WebApplication1.Data.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        public TagsService _tagsService;

        public TagsController(TagsService tagsService)
        {
            _tagsService = tagsService;
        }

        [HttpPost("add-like")]
        public IActionResult AddLike([FromBody] TagVM tag)//[FromBody] from body of teh request
        {
            _tagsService.AddTag(tag);
            return Ok();
        }

        [HttpGet("get-all-likes")]
        public IActionResult GetAllLikes()
        {
            var allLike = _tagsService.GetAllTags();
            return Ok(allLike);
        }


        [HttpGet("get-like-by-id/{id}")]
        public IActionResult GetlikeById(int id)
        {
            var post = _tagsService.GetTagById(id);
            return Ok(post);
        }


        [HttpDelete("delete-like-by-id/{id}")]
        public IActionResult DeleteLiById(int id)
        {
            _tagsService.DeleteTagById(id);
            return Ok();
        }
    }
}
