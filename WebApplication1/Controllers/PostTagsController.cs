using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostTagsController : ControllerBase
    {
        public PostTagsService _postTagsService;


        public PostTagsController(PostTagsService postTagsService)
        {
            _postTagsService = postTagsService;
        }

     

        [HttpDelete("delete-postTags-by-postid/{postid}")]
        public IActionResult DeletePosTagsByPostId(int postid)
        {
            _postTagsService.DeletePosTagsByPostId(postid);
            return Ok();
    }
        

    }
}
