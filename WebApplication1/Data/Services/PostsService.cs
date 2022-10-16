using WebApplication1.Data.Models.ViewModels;
using WebApplication1.Models;

namespace WebApplication1.Data.Services
{
    public class PostsService
    {
        private AppDbContext _context;

        public PostsService(AppDbContext context)
        {

            _context = context;
        }

        public void AddPost(PostVM post)
        {
            var _post = new Post()
            {
                //userName = post.userName,

                link = post.link,

                image = post.image,

                title = post.title,

                date = post.date,

                time = post.time,

                discription = post.discription,

                isActive = post.isActive

            };
            _context.Posts.Add(_post);//add data to database
            _context.SaveChanges();

        }

        public List<Post> GetAllPosts() => _context.Posts.ToList();

        public Post GetPostById(int Id) => _context.Posts.FirstOrDefault(n => n.postId == Id);

        public Post UpdatePostById(int Id, PostVM post)
        {
            var _post = _context.Posts.FirstOrDefault(n => n.postId == Id);//FirstOrDefault:search find the first match or?

            if (_post != null)
            {
                _post.link = post.link;

                _post.image = post.image;

                _post.title = post.title;

                _post.date = post.date;

                _post.time = post.time;

                _post.discription = post.discription;

                _post.isActive = post.isActive;

                _context.SaveChanges();
            }

            return _post;
        }

        public void DeletePostById(int Id)
        {
            var _post = _context.Posts.FirstOrDefault(n => n.postId == Id);
                if(_post!=null)
            {
                _context.Posts.Remove(_post);
                _context.SaveChanges();
            }
        }
    }

}
