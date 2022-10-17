using WebApplication1.Models;

namespace WebApplication1.Data.Models.ViewModels
{
    public class CommentVM
    {


        public string userName { get; set; }
        //public User User { set; get; }// foreign key to user

        public string comment { get; set; }
        public long date { get; set; }
        public string time { get; set; }
        public bool isActive { get; set; }

        //public int postId { get; set; }
        //public Post Post { get; set; }//foreign key to post
    }
}
