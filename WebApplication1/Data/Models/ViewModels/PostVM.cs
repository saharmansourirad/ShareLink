using WebApplication1.Models;

namespace WebApplication1.Data.Models.ViewModels
{
    public class PostVM
    {
        //public int postId { get; set; }

        public string userName { get; set; } //foregion key from user

        public string link { get; set; }

        public string image { get; set; }

        public string title { get; set; }

        public long date { set; get; }

        public int time { set; get; }

        public string discription { get; set; }

        public bool isActive { get; set; }

        public int likeCount { get; set; }

        public int commentCount { get; set; }

        public List<string> Tags { get; set; }

        //public List<CommentVM> Comments { get; set; }
 

    }

    public class GetPostVM
    {
        public int postId { get; set; }

        public string userName { get; set; } //foregion key from user

        public string link { get; set; }

        public string image { get; set; }

        public string title { get; set; }

        public long date { set; get; }

        public int time { set; get; }

        public string discription { get; set; }

        public bool isActive { get; set; }

        public int likeCount { get; set; }

        public int commentCount { get; set; }

        public List<string> Tags { get; set; }

        //public List<CommentVM> Comments { get; set; }


    }
}
