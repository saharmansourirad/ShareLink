using System.Collections.Generic;
using WebApplication1.Data.Models;
using WebApplication1.Data.Models.ViewModels;
using WebApplication1.Models;

namespace WebApplication1.Data.Services
{
    public class PostsService
    {
        private AppDbContext _context;

        public TagsService _tagsService;

        public CommentsService _commentsService;

        public PostTagsService _postTagsService;

        public PostsService(AppDbContext context, TagsService tagsService,CommentsService commentsService,PostTagsService postTagsService)
        {

            _context = context;

            _tagsService = tagsService;

            _commentsService = commentsService;

            _postTagsService = postTagsService;
        }

        public void AddPost(PostVM post)
        {        

            var _post = new Post()
            {
                userName = post.userName,

                link = post.link,

                image = post.image,

                title = post.title,

                //dateTime =DateTime.Now.ToString("MM/dd/yyyy")

                date = DateTime.Now.ToString("yyyy-MM-dd"),

                time = DateTime.Now.ToString("HH:mm:ss"),

                discription = post.discription,

                isActive = post.isActive

            };

            _context.Posts.Add(_post);//add data to database
            _context.SaveChanges();

            List<string> tagsList = post.Tags;
        

            for (int i = 0; i < tagsList.Count; i++)
            {
                //_tagsService.AddTag(tagsList[i],_post.postId);

                var __tag = _context.Tags.FirstOrDefault(n => n.tag == tagsList[i]);

                if(__tag==null)
                {
                    //_tagsService.AddTag(tagsList[i], _post.postId);

                    var _tag = new Tag()
                    {

                        tag = tagsList[i],

                        date = DateTime.Now.ToString("yyyy-MM-dd"),

                        time = DateTime.Now.ToString("HH:mm:ss"),

                        isActive = true

                    };
                    _context.Tags.Add(_tag);
                    _context.SaveChanges();

                    var _postTag = new PostTag()
                    {

                        postId = _post.postId,
        
                         tagId = _tag.tagId
                     };


                    _context.PostTags.Add(_postTag);
                   _context.SaveChanges();
                }
                else if(__tag!=null)
                {
                    //var __postTag = _context.PostTags.Where(n => n.tagId == __tag.tagId && n.postId == _post.postId).ToList();

                    var _postTag = new PostTag()
                    {

                        postId = _post.postId,

                        tagId = __tag.tagId
                    };


                    _context.PostTags.Add(_postTag);
                  _context.SaveChanges();
                }

             
            }

            
        }

        public List<GetPostVM> GetAllPosts()
        {

            List<Post> postList = _context.Posts.ToList();

            List<GetPostVM> finalPostList=new List<GetPostVM>();

            //List<PostTagVM> postTagList = new List<PostTagVM>();

            for (int i=0;i< postList.Count; i++)
            {
                
                var postLikes = _context.Likes.Where(e => e.postId == postList[i].postId).Count();

                var postComments = _context.Comments.Where(e => e.postId == postList[i].postId).Count();

               

                //var d = _context.Posts.Select(e => e.postId == postList[i].postId);


                var postTagList = _context.PostTags.Where(e => e.postId == postList[i].postId).ToList();

                List<string> tags = new List<string>();

                foreach (PostTag postTag in postTagList)
                {
                    var _tagName = _context.Tags.Where(n => n.tagId == postTag.tagId).FirstOrDefault().tag;

                    tags.Add(_tagName);
                }
               


                //var postComments = _context.Comments.Where(e => e.postId == postList[i].postId).ToList();returns list of all comments

                var _post = new GetPostVM()
                {
                    postId=postList[i].postId,

                    userName = postList[i].userName,

                    link = postList[i].link,

                    image = postList[i].image,

                    title = postList[i].title,

                    sharedDate= postList[i].date+'T'+ postList[i].time+'Z',

                    discription = postList[i].discription,

                    isActive = postList[i].isActive,

                    likeCount = postLikes,

                    commentCount = postComments,

                    Tags= tags

                };

                finalPostList.Add(_post);

            }

            return finalPostList;

        }



        public Post GetPostById(int Id) => _context.Posts.FirstOrDefault(n => n.postId == Id);

        public Post UpdatePostById(int Id, PostVM post)
        {
            var _post = _context.Posts.FirstOrDefault(n => n.postId == Id);//FirstOrDefault:search find the first match or?

            if (_post != null)
            {
                _post.link = post.link;

                _post.image = post.image;

                _post.title = post.title;

                _post.date = DateTime.Now.ToString("yyyy-MM-dd");

                _post.time = DateTime.Now.ToString("HH:mm:ss");

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
              

                _postTagsService.DeletePosTagsByPostId(Id);

                _commentsService.DeleteComentsByPostId(Id);

                _context.Posts.Remove(_post);

                _context.SaveChanges();


            }


       
        }

    }

}
