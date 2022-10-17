using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Data.Models;

namespace WebApplication1.Models
{
    public class User
    {
        
        public int userId { get; set; }

     [Key]

        //[Indexed(Unique = true)]
        public string userName { get; set; }

        public string userProfile { set; get; }

        public string firstName { get; set; }

        public string lastName { get; set; }


        public int password { get; set; }

        public string salt { get; set; }


        public string email { get; set; }



        public List<Post> Posts {get; set;}

        public List<Comment> Comments { get; set; }

        public List<Like> Likes { get; set; }
    
    }
}
