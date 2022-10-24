using WebApplication1.Data.Models;
using WebApplication1.Data.Models.ViewModels;

namespace WebApplication1.Data.Services
{
    public class LikesService
    {

        AppDbContext _context;

        public LikesService(AppDbContext context)
        {
            _context = context;
        }

        public void AddLike(LikeVM like)
        {

            List<Like> likes = _context.Likes.Where(n => n.postId == like.postId && n.userName == like.userName).ToList();

            if(likes.Count == 0)
            {
               
                        var _like = new Like()
                        {

                            postId = like.postId,

                            userName = like.userName,

                            date = DateTime.Now.ToString("yyyy-MM-dd"),

                            time = DateTime.Now.ToString("HH:mm:ss"),

                            isActive = like.isActive
                        };
                        _context.Likes.Add(_like);//add data to database
                        _context.SaveChanges();    
                
            }
   

        }

        public List<Like> GetAllLikes() => _context.Likes.ToList();

        public Like GeLikeByPostId(int PostId) => _context.Likes.FirstOrDefault(n => n.postId == PostId);


        public void DeleteLikeByPostId(int PostId)
        {
            var _like = _context.Likes.FirstOrDefault(n => n.postId == PostId);
            if (_like != null)
            {
                _context.Likes.Remove(_like);
                //_like.isActive = false;
                _context.SaveChanges();
            }
        }
    }
}
