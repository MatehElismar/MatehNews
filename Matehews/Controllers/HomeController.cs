using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Matehews.Models;

namespace Matehews.Controllers
{ 
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {    
            return View(Program.Posts);
        }

        public IActionResult Sections(string name = "Finanzas")
        {    
            ViewBag.Categories = Program.Categories; 
            return View(Program.SelectReviews(name));
        }

        public IActionResult Post(string id)
        {   
            var post = Program.GetPost(id);
            if(post != null)
            {
                Console.WriteLine("I Am A Post");
                ViewBag.Categories = Program.Categories; 
                return View(post);

            }
            return Json("Post not found");
            
        } 
 
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page."; 
            return View( );
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
