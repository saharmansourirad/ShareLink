using WebApplication1.Data.Models.ViewModels;
using WebApplication1.Models;

namespace WebApplication1.Data.Services
{
    public class CommentsService

     {
        private AppDbContext _context;


        public CommentsService(AppDbContext context)
        {
            _context = context;
        }


        public void AddComment(CommentVM comment)
        {
            var _comment=new Comment()
            {
               // userName= userName,
                comment =comment.comment,
                postId=comment.postId,
                date=comment.date,
                time=comment.time,
                isActive=comment.isActive,
                userName=comment.userName

            };
            _context.Comments.Add(_comment);
            _context.SaveChanges();
        }

        public List<CommentVM> GetAllComments(int postId)
        {
            List<CommentVM > finalCommentsList= new List<CommentVM>();

            var comments = _context.Comments.Where(e => e.postId == postId).ToList();


            foreach(Comment comment in comments)
            {
                var _comment = new CommentVM()
                {
                    userName = comment.userName,

                    comment = comment.comment,

                    date = comment.date,

                    time = comment.time, 

                    isActive = comment.isActive

                };
                finalCommentsList.Add(_comment);
            }


            return finalCommentsList;
        } 

        
        
        public Comment GetCommentById(int Id) => _context.Comments.FirstOrDefault(n => n.commentId == Id);


        public void DeleteComentById(int Id)
        {
            var _comment = _context.Comments.FirstOrDefault(n => n.commentId == Id);
            if (_comment != null)
            {
                _context.Comments.Remove(_comment);
                _context.SaveChanges();
            }
        }
    }
}
