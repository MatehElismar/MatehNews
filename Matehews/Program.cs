﻿using System;
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
        public static List<Categorie> Categories{ get; set;} 

        static Program()
        {
            users = new List<User>();
            Posts = new List<News>();
            Logs = new List<User>();
            Categories = new List<Categorie>();

            Categories.Add(new Categorie("Finanzas"));
            Categories.Add(new Categorie("Deportanzas"));
            Categories.Add(new Categorie("Robanzas"));
            Categories.Add(new Categorie("Alabanzas"));
 
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac...","Finanzas","newspaper-template/img/bg-img/12.jpg"));
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac...","Finanzas", "newspaper-template/img/bg-img/13.jpg"));
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac...","Finanzas"));
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac...","Deportanzas"));
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac...","Deportanzas"));
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac...","Deportanzas"));
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac...","Alabanzas"));
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac...","Alabanzas"));
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac...","Alabanzas"));
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac...","Alabanzas"));
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac...","Alabanzas"));
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac...","Alabanzas"));
            Posts.Add(new News("Alfredo se hizo rico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu metus sit amet odio sodales placerat. Sed varius leo ac...","Robanzas"));

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

        public static List<News> SelectReviews(string categorie){
            var l = new List<News>();
            var count = 0;
            foreach (var item in Program.Posts)
            {
                if(item.categorieName == categorie && count <10)
                {
                    var post = new News();
                    post.title = item.title;
                    post.review = item.review; 
                    l.Add(post);
                    count++;
                }
            }
            return l;

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
