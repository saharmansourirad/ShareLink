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

        [HttpPost("add-tag")]
        public IActionResult AddTag([FromBody] string tag)//[FromBody] from body of teh request
        {
            _tagsService.AddTag(tag);
            return Ok();
        }

        [HttpGet("get-all-tags")]
        public IActionResult GetAllTags()
        {
            var allTags = _tagsService.GetAllTags();
            return Ok(allTags);
        }


        [HttpGet("get-tag-by-id/{id}")]
        public IActionResult GetTagById(int id)
        {
            var tag = _tagsService.GetTagById(id);
            return Ok(tag);
        }


        [HttpDelete("delete-tag-by-id/{id}")]
        public IActionResult DeleteTagById(int id)
        {
            _tagsService.DeleteTagById(id);
            return Ok();
        }

        [HttpDelete("delet-tag-by-tagname")]
        public IActionResult DeleteTagByTagName(string tagname)
        {
            _tagsService.DeleteTagByTagName(tagname);
            return Ok();
        }
    }
}
