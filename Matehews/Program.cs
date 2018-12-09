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

            var u = new User();
            u.first = "Admin";
            u.last = "Prro";
            u.email = "a@a.com"; 
            u.pass = "123";
            u.accessKey = 100;
            users.Add(u);
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
