using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Data.Models
{
    public class Like
    {
        [Key]
        public int likeId { get; set; }


        public int postId { get; set; }

        public Post Post { get; set; }


        public string userName { get; set; }

        public User User { get; set; }


        public long date { get; set; }

        public string time { get; set; }

        public bool isActive { get; set; }

        //public ICollection<Post> Post { get; set; }

    }


}
