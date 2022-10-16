using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(b => b.Posts)
                .HasForeignKey(p => p.userName);

            modelBuilder.Entity<Like>()
               .HasOne(p => p.Post)
               .WithMany(b => b.Likes)
               .HasForeignKey(p => p.postId);

            modelBuilder.Entity<Comment>()
               .HasOne(p => p.Post)
               .WithMany(b => b.Comments)
               .HasForeignKey(p => p.postId);

            modelBuilder.Entity<Comment>()
               .HasOne(p => p.User)
               .WithMany(b => b.Comments)
               .HasForeignKey(p => p.userName);

            modelBuilder.Entity<Like>()
               .HasOne(p => p.User)
               .WithMany(b => b.Likes)
               .HasForeignKey(p => p.userName);




        }

    }
}
