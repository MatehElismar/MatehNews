using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Matehews.Models;

namespace Matehews
{
    public class Program
    {
        public static List<User> users{ get; set;} 
        public static List<User> Logs{ get; set;} 
        public static List<News> Posts{ get; set;} 

        static Program()
        {
            users = new List<User>();
            Posts = new List<News>();
            Logs = new List<User>();
 
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac...","newspaper-template/img/bg-img/12.jpg"));
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac...", "newspaper-template/img/bg-img/13.jpg"));
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac..."));
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac..."));
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac..."));
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac..."));
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac..."));
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac..."));
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac..."));
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac..."));
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac..."));
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac..."));
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac..."));

            var u = new User();
            u.id = 1;
            u.first = "Admin";
            u.last = "Prro";
            u.email = "a@a.com"; 
            u.pass = "123";
            u.accessKey = 100;

            var e = new User();
            e.id = 2;
            e.first = "Usuario Comun";
            e.email = "e@e.com";   
            e.pass = "1234";
            e.accessKey = 102;
            users.Add(u);
            users.Add(e);

        }


        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
