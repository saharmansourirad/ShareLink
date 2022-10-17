namespace WebApplication1.Data.Models.ViewModels
{
    public class UserVM
    {

        public int userId { get; set; }

        public string userName { get; set; }

        public string userProfile { set; get; }

        public string firstName { get; set; }

        public string lastName { get; set; }


        public int password { get; set; }

        public string salt { get; set; }


        public string email { get; set; }



        //public List<Post> Posts { get; set; }

        //public List<Comment> Comments { get; set; }

        //public List<Like> Likes { get; set; }
    }
}
