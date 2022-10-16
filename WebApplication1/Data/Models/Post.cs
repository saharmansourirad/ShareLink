using System.ComponentModel.DataAnnotations;
using WebApplication1.Data.Models;

namespace WebApplication1.Models
{
    public class Post
    {

        [Key]
        public int postId { get; set; }


        public string userName { get; set; } //foregion key from user

        public User User { get; set; }

   

        public string link { get; set; }

        public string image { get; set; }

        public string title { get; set; }

        public long date { set; get; }

        public int time { set; get; }

        public string discription { get; set; }


        //public ICollection<Tag> Tags { get; set; }

        public ICollection<PostTag> Tags { get; set; }// one post relation to many tags and any tag relation to many post


        public List<Like> Likes { get; set; }// vote table


        public List<Comment> Comments { get; set; }

        


    }
}
