namespace WebApplication1.Models
{
    public class Comment
    {
        public int id { get; set; }

        public string userName { get; set; }

        public string userProfile { get; set; }

        public string comment { get; set; }

        public DateTime commentDate { get; set; }

        public int likes { get; set; }
      
    }
}
