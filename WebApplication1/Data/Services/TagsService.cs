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

        public void AddTag(TagVM tag)
        {
            var _tag = new Tag()
            {
                 tagId=tag.tagId,

                 tag=tag.tag,

                date=tag.date,

                time=tag.time,

                isActive=tag.isActive

            };
            _context.Tags.Add(_tag);
            _context.SaveChanges();
        }

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
    }
}
