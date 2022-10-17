using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Comment
    {
        [Key]
        public int commentId { get; set; }
        public string userName { get; set; }
        public User User { set; get; }// foreign key to user

        public string comment { get; set; }
        public long date { get; set; }
        public string time { get; set; }
        public bool isActive { get; set; }

        public int? postId { get; set; }
        public Post Post { get; set; }//foreign key to post


        // public List<Post> Post { get; set; }





        // public int likes { get; set; }

    }


}
