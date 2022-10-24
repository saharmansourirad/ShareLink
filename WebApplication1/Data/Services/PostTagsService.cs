using WebApplication1.Data.Models;

namespace WebApplication1.Data.Services
{
    public class PostTagsService
    {
        private AppDbContext _context;

        public PostTagsService(AppDbContext context)
        {
            _context = context;
        }

        public void DeletePosTagsByPostId(int postId)
        {

            var _postTags = _context.PostTags.Where(n => n.postId == postId).ToList();
            if (_postTags != null)
            {
                foreach (PostTag postTag in _postTags)
                {
                    _context.PostTags.Remove(postTag);
                    _context.SaveChanges();
                }
            }




        }
    }
}
