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

            var __like = _context.Likes.FirstOrDefault(n => n.postId == like.postId);
             if(__like!=null && __like.userName == like.userName)
            {

                    this.DeleteLikeById(__like.likeId); 
            }
             else
            {
                var _like = new Like()
                {

                    postId = like.postId,

                    userName = like.userName,

                    date = like.date,

                    time = like.time,

                    isActive = like.isActive
                };
                _context.Likes.Add(_like);//add data to database
                _context.SaveChanges();
            }
          

        }

        public List<Like> GetAllLikes() => _context.Likes.ToList();

        public Like GeLikeById(int Id) => _context.Likes.FirstOrDefault(n => n.likeId == Id);


        public void DeleteLikeById(int Id)
        {
            var _like = _context.Likes.FirstOrDefault(n => n.likeId == Id);
            if (_like != null)
            {
                //_context.Likes.Remove(_like);
                _like.isActive = false;
                _context.SaveChanges();
            }
        }
    }
}
