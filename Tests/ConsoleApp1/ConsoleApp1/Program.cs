using Microsoft.EntityFrameworkCore;
using BlogProj.Data;
using BlogProj.Shared.Models;
using BlogProj.Data.Repositories;
using System.Runtime.CompilerServices;
using BlogProj.Core.Services;
using AutoMapper;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (DataBaseContext dBContext = new DataBaseContext())
            {
                //dBContext.Database.EnsureDeleted();
                dBContext.Database.EnsureCreated();
            }

            using DataBaseContext dbContext = new DataBaseContext();
            var blog = dbContext.Blogs.Include(b => b.Posts).ThenInclude(p => p.Comments).FirstOrDefault();

            Console.WriteLine($"Blog: {blog}\n");
            Console.WriteLine("Posts: \n");
            foreach (var post in blog.Posts)
            {
                Console.WriteLine("Post: " + post);
                Console.WriteLine("Comments:");
                foreach (var comment in post.Comments)
                {
                    Console.WriteLine(comment);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        private static void ReadAndWriteInConsoleUserWithId(int Id)
        {
            
        }

        private static void ReadAndWriteInConsoleAllUsers()
        {
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                var users = dbContext.Users.ToList();
                foreach (var user in users)
                {
                    Console.WriteLine(user);
                    Console.WriteLine();
                }
                Console.WriteLine("\nEnd of loop");
            }
            Console.ReadKey();
        }

        public async void CreateBlog()
        {
            using DataBaseContext dbContext = new DataBaseContext();
            BlogRepository blogRepository = new BlogRepository(dbContext);
            Blog blog = new Blog()
            {
                Title = "Blog 1 title"
            };
            await blogRepository.CreateBlogAsync(blog);
        }

        private static void ReadBlogsExtended()
        {
            using DataBaseContext dbContext = new DataBaseContext();

            var blogs = dbContext.Blogs.Include(b => b.Posts).ToList();
            foreach (var blog in blogs)
            {
                Console.WriteLine($"Blog: {blog.Title}");
                Console.WriteLine("Posts :");
                foreach (var post in blog.Posts)
                {
                    Console.WriteLine($"{post}");
                }
            }
            Console.ReadKey();
        }

        private static void ReadBlogs()
        {
            using DataBaseContext dbContext = new DataBaseContext();

            var blogs = dbContext.Blogs.ToList();
            Console.WriteLine("Blogs :");
            foreach (var blog in blogs)
            {
                Console.WriteLine(blog);
            }
            Console.ReadKey();
        }

        private static void ReadComments()
        {
            using DataBaseContext dbContext = new DataBaseContext();

            var comments = dbContext.Comments.Where(c => c.Post.Id == 1).ToList();
            Console.WriteLine("Comments :");
            foreach (var comment in comments)
            {
                Console.WriteLine(comment);
            }
            Console.ReadKey();
        }

        private static void CreatePosts()
        {
            DataBaseContext dbContext = new DataBaseContext();

            Post post = new Post()
            { 
                Title = "How to make a chocolate cake",
                Owner = dbContext.Users.FirstOrDefault(u => u.Credentials != null),
                Content = "Hello, today I'm gonna tell you how to make a chocolate cake at home...",
                Blog = dbContext.Blogs.FirstOrDefault(b => b.Title == "Cooking")
            };
            dbContext.Posts.Add(post);

            Post post1 = new Post()
            {
                Title = "Pancakes for everyone",
                Owner = dbContext.Users.FirstOrDefault(u => u.Credentials != null),
                Content = "Who doesn't love pancakes? Everyone does, so today I'm gonna...",
                Blog = dbContext.Blogs.FirstOrDefault(b => b.Title == "Cooking")
            };
            dbContext.Posts.Add(post1);

            dbContext.SaveChanges();
        }

        private static void CreateComments()
        {
            DataBaseContext dbContext = new DataBaseContext();

            Comment comment = new Comment()
            {
                Author = dbContext.Users.FirstOrDefault(u => u.Id == 4),
                Content = "Hey, I like your blog :)",
                Post = dbContext.Posts.FirstOrDefault()
            };

            dbContext.Comments.Add(comment);

            Comment comment1 = new Comment()
            {
                Author = dbContext.Users.FirstOrDefault(u => u.Credentials != null),
                Content = "Hey, it's me again. Thank you for your work, I really made that cake thanks to you",
                Post = dbContext.Posts.FirstOrDefault()
            };
            dbContext.Comments.Add(comment1);

            dbContext.SaveChanges();
        }

        private static void CreateBlogs()
        {
            DataBaseContext dbContext = new DataBaseContext();

            Blog blog = new Blog() { Title = "Cooking" };
            dbContext.Blogs.Add(blog);

            dbContext.SaveChanges();
        }

        private static void CreateUsers()
        {
            using DataBaseContext dBContext = new DataBaseContext();

            User user = new User() { AuthorizationType = AuthorizationType.None };
            dBContext.Users.Add(user);

            Credentials credentials = new Credentials() { Login = "kovtunets33@gmail.com", Password = "password_123" };

            User user1 = new User() { AuthorizationType = AuthorizationType.User, Credentials = credentials };
            dBContext.Users.Add(user1);

            User user2 = new User() { AuthorizationType = AuthorizationType.None };
            dBContext.Users.Add(user2);

            Credentials credentials3 = new Credentials() { Login = "kovtunets1040@gmail.com", Password = "code_word77" };

            User user3 = new User()
            {
                AuthorizationType = AuthorizationType.User,
                FirstName = "TestName",
                LastName = "LastName",
                UserName = "YellowFlash",
                Credentials = credentials3
            };
            dBContext.Users.Add(user3);


            dBContext.SaveChanges();
        }
    }
}