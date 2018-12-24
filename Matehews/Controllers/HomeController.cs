using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Matehews.Models;
using Services;

namespace Matehews.Controllers
{ 
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {    
                ViewBag.TopTen = Program.GetTopTenPosts();
                 var post = PostService.GetTopOfPosts(10);
                 Debug.WriteLine(post.Count);
                return View(post);
        }

        public IActionResult Sections(string name = "Finanzas")
        {    
            ViewBag.Categories = PostService.SelectCategories(); 
            return View(PostService.GetTopReviews(name, 10));
        }

        public IActionResult Post(string id)
        {   
            var post = PostService.GetPost(id);
            post.comments = CommentService.GetComments(post.id);
            if(post != null)
            { 
                ViewBag.AboutAuthor = AccountService.GetUserProfileByID(post.userID).aboutMe;
                ViewBag.Categories = PostService.SelectCategories(); 
                return View(post);

            }
            return Json("Post not found");
            
        }  

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
              
            return View();
        }

        public IActionResult Privacy()
        {
              
            return View();
        }
        
        public IActionResult NotFound()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
