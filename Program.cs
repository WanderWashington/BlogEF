using System;
using System.Collections.Generic;
using BlogEf.Data;
using BlogEf.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogEf // Note: actual namespace depends on the project name.
{
    class Program
    {
        static async Task Main(string[] args)
        {
            #region Crud
            // using(var context = new BlogDataContext())
            // {   
            //     #region CRUD
            //     //Create
            //     // var tag = new Tag { Name ="Entity Framework", Slug="entity"};
            //     // context.Tags.Add(tag);
            //     // context.SaveChanges();

            //     // //Update
            //     // var tag = context.Tags.FirstOrDefault(x=> x.Id == 4);
            //     // tag.Name = ".NET 5";
            //     // tag.Slug = "dotnet";
            //     // context.Update(tag);
            //     // context.SaveChanges();

            //     //Delete
            //     // var tag = context.Tags.FirstOrDefault(x=> x.Id == 4);
            //     // context.Remove(tag);
            //     // context.SaveChanges();

            //     // var tags = context.Tags.AsNoTracking().ToList();

            //     // foreach (var item in tags)
            //     // {
            //     //     Console.WriteLine($"{item.Name}");
            //     // }
            //     #endregion


            // }
            #endregion
            
            using var context = new BlogDataContext();

            #region CRUD entity
            //INCLUDE
            // var user = new User
            //     {
            //         Name = "Joãozinho",
            //         Slug = "jãozin", 
            //         Email = "jaozin@gmail.com",
            //         Bio = "future developer",
            //         Image = "https://balta.io",
            //         PasswordHash = "123456789"
            //     };
            // var category = new Category {
            //     Name = "Backend", 
            //     Slug = "backend"
            // };

            // var post = new Post {
            //     Author = user,
            //     Category = category,
            //     Body = "<p>Hello world</p>",
            //     Slug = "comecando-com-ef-core",
            //     Summary = "Neste artigo vamos aprender EF Core",
            //     Title = "Começando com o EF Core",
            //     CreateDate = DateTime.Now,
            //     LastUpdateDate = DateTime.Now,
            // };
            // //ele ja adiciona os outros objetos antes.
            // context.Posts.Add(post);
            // context.SaveChanges();

            //READ
            // var posts = context
            // .Posts
            // .AsNoTracking()
            // .Include(x=> x.Author)
            // .Include(x=> x.Category)
            //     //.ThenInclude(x=> x.Id) subselect.
            // .Where(x=>x.AuthorId == 1002)
            // .OrderBy(x=> x.LastUpdateDate).ToList();

            // foreach (var post in posts)
            // {
            //     Console.WriteLine($"{post.Title} escrito por {post.Author?.Name} em {post.Category?.Name}");
            // }

            //UPDATE
            // var post = context
            // .Posts
            // .Include(x=>x.Author)
            // .Include(x=> x.Category)
            // .OrderByDescending(x=>x.LastUpdateDate)
            // .FirstOrDefault();

            // post.Author.Name = "Wander";
            // context.Posts.Update(post);
            // context.SaveChanges();

            // context.Users.Add(new User {            
            //         Name = "Joãozinho",
            //         Slug = "teste", 
            //         Email = "teste@gmail.com",
            //         Bio = "future developer",
            //         Image = "https://balta.io",
            //         PasswordHash = "123456789" });

            // context.SaveChanges();
            // var user = context.Users.FirstOrDefault();
            // var post = new Post {
            //     Author = user,
            //     Body = "Meu Artigo",
            //     Category = new Category {
            //         Name = "Front",
            //         Slug = "front-end"
            //     },
            //     CreateDate = System.DateTime.Now,
            //     //LastUpdateDate = 
            //     Slug = "meu-artigo",
            //     Summary = "Neste artigo vamos conferir...",
            //     //Tags = null,
            //     Title = "Meu Artigo"
            // };
            // context.Posts.Add(post);
            // context.SaveChanges();
            #endregion

            #region Async examples
            // var post = await context.Posts.ToListAsync();
            // var tags = await context.Users.ToListAsync();

            // var posts = await GetPosts(context);
            // Console.WriteLine(posts.Count());
            #endregion

            #region lazy loading e eager loading
            // var posts = context.Posts;
            // foreach (var post in posts)
            // {
            //     foreach (var tags in post.Tags)
            //     {
                    
            //     }
            // }
            //eager loading 
            // var posts2 = context.Posts.Include(x=> x.Tags);
            // foreach (var post in posts2)
            // {
            //     foreach (var tag in post.Tags)
            //     {
                    
            //     }
            // }

            #endregion
        
            // var posts = context.PostWithTagsCounts.ToList();
            // foreach (var item in posts)
            // {
            //     Console.WriteLine($"{item?.PostsQuantity}");
            // }
            Console.WriteLine("teste");
       
        }

        public static async Task<IEnumerable<Post>> GetPosts(BlogDataContext context){
            return await context.Posts.ToListAsync();
        }
        
        public static List<Post> GetPosts(BlogDataContext context, int skip = 0, int take = 25){
            var posts = context.Posts
                .AsNoTracking()
                .Skip(skip)
                .Take(take).ToList();
            return posts;
        }
    }
}