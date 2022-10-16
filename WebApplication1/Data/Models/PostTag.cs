using WebApplication1.Models;

namespace WebApplication1.Data.Models
{
    public class PostTag
    {
        public int id { get; set; }
        public int postId { get; set; }
        public Post Post { get; set; }
        public int tagId { get; set; }
        public Tag Tag { get; set; }

    }
}
