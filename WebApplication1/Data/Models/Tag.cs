using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Data.Models
{
    public class Tag
    {

        [Key]
        public int tagId { get; set; }

        public string tag { get; set; }

        public long date { get; set; }

        public string time { get; set; }

        public bool isActive { get; set; }

        public ICollection<Post> Posts { get; set; }


    }
}
