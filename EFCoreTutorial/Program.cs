using System;
using System.Linq;

namespace EFCoreTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var database = new BloggingContext())
            {
                // Create
                Console.WriteLine("Inserting new blog");
                database.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                database.SaveChanges();

                // Read 
                Console.WriteLine("Querying for a blog");
                var blog = database.Blogs
                    .OrderBy(b => b.BlogId)
                    .FirstOrDefault();

                // Update
                Console.WriteLine("Updating the blog and adding a post");
                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(
                    new Post { 
                    Title = "Hello World", 
                    Content = "This is my first EF Core app!" });
                database.SaveChanges();

                // Delete
                Console.WriteLine("Delete the blog");
                database.Remove(blog);
                database.SaveChanges();
            }
        }
    }
}



      