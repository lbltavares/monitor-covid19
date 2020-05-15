using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using monitor_covid19.Models;


namespace monitor_covid19
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new CovidContext())
            {
                // Create
                // db.Add(
                //     new PaisModel
                //     {
                //         Nome = "Brasil",
                //     }
                // );
                // db.SaveChanges();

                // Read
                var pais = db.Paises
                            .OrderBy(b => b.Nome)
                            .First();;
                Console.WriteLine(pais.Nome);

                // // Update
                // Console.WriteLine("Updating the blog and adding a post");
                // blog.Url = "https://devblogs.microsoft.com/dotnet";
                // blog.Posts.Add(
                //     new Post
                //     {
                //         Title = "Hello World",
                //         Content = "I wrote an app using EF Core!"
                //     });
                // db.SaveChanges();

                // // Delete
                // Console.WriteLine("Delete the blog");
                // db.Remove(blog);
                // db.SaveChanges();

                CreateHostBuilder(args).Build().Run();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
