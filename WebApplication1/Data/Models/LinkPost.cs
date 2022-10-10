namespace WebApplication1.Models
{
    public class LinkPost
    {

        public int id { get; set; }

        public string userProfile { get; set; }

        public string userName { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string link { get; set; }

        public string image { get; set; }

        public string title { get; set; }

        public string discription { get; set; }

        public string caption { get; set; }

        public string[] tags { get; set; }

        public Comment[] comments { get; set; }


    }
}
