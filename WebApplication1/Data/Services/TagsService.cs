using WebApplication1.Data.Models;
using WebApplication1.Data.Models.ViewModels;

namespace WebApplication1.Data.Services
{
    public class TagsService
    {
        AppDbContext _context;

        public TagsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddTag(string tag)
        {
            
                var _tag = new Tag()
                {

                    tag = tag,

                    date =  DateTime.Now.ToString("yyyy-MM-dd"),

                    time = DateTime.Now.ToString("’HH’:’mm’:’ss"),

                    isActive = true

                };
                _context.Tags.Add(_tag);
                _context.SaveChanges();  
                
                ////add posttag
            
            //else if(__tag!=null)
            //{
            //    var __postTag = _context.PostTags.Where(n => n.tagId == __tag.tagId && n.postId==postId).ToList();
            //    var _p=
            //     var __myTagPost= 
            //    if (__postTag.tagId != __tag.tagId)

            //    {
            //        var _postTag = new PostTag()
            //        {

            //            postId = postId,

            //            tagId= __tag.tagId
            //        };
            //    }
              
                 

                
            //}

        }

        //public void AddTag(TagVM tag)
        //{
        //    var __tag= _context.Tags.FirstOrDefault(n => n.tag == tag.tag);

        //    if(__tag==null)
        //    {
        //        var _tag = new Tag()
        //        {

        //            tag = tag.tag,

        //            date = tag.date,

        //            time = tag.time,

        //            isActive = tag.isActive

        //        };

              
        //        _context.Tags.Add(_tag);
        //        _context.SaveChanges();
        //    }
           
        //}

        public List<Tag> GetAllTags() => _context.Tags.ToList();

        public Tag GetTagById(int Id) => _context.Tags.FirstOrDefault(n => n.tagId == Id);


        public void DeleteTagById(int Id)
        {
            var _tag = _context.Tags.FirstOrDefault(n => n.tagId == Id);
            if (_tag != null)
            {
                //_context.Tags.Remove(_tag);
                _tag.isActive = false;
                _context.SaveChanges();
            }
        }

        public void DeleteTagByTagName(string Tag)
        {
            var _tag = _context.Tags.FirstOrDefault(n => n.tag == Tag);
            if (_tag != null)
            {
                _context.Tags.Remove(_tag);
                //_tag.isActive = false;
                _context.SaveChanges();
            }
        }
    }
}
