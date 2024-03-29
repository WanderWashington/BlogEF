using Blog.Data.Mappings;
using BlogEf.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogEf.Data
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        // public DbSet<Tag> Tags { get; set; }
        // public DbSet<PostTag> PostTags { get; set; }
        // public DbSet<Role> Roles { get; set; }
        // public DbSet<UserRole> UserRoles { get; set; }
        
        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        //     {
        //         options.UseSqlServer("Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;");
        //         options.LogTo(Console.WriteLine);
        //     }


        public DbSet<PostWithTagsCount> PostWithTagsCounts {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            =>options.UseSqlServer("Server=localhost,1433;Database=BlogFluentMap;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());

            modelBuilder.Entity<PostWithTagsCount>(x=> {
                x.ToSqlQuery(@"Select 
                                    [Title] as [Name],
                                    Select Count([Id]) from [Tags] where [PostId] = [Id] as [PostsQuantity]
                               from [Posts]");
            });
        }
    }
}