using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Matehews.Models;
using Services;

namespace Matehews.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult CPanel( )
        {  
            return View( ); 
        }

        public IActionResult ManageUsers()
        {
             
            return View();
        }


          public IActionResult AddNews()
        {
             
            return View();
        }

        [HttpPost]
        public IActionResult AddPost([FromBody]newsRequest response)
        {
            if(Program.users.Find(x => x.id == response.user.id) != null && response.user.accessKey < 102)
            { 
                response.post.id = Program.Posts.Count + 1;
                Program.Posts.Add(response.post);
                return Json(Program.Posts);
            }
            return Json(null);
        }

        public IActionResult AddSections()
        {
             
            return View();
        }

        public IActionResult RemoveNews()
        {
             
            return View();
        } 
    }

    public class newsRequest
    {
        public User user{ get; set; }
        public News post{ get; set; }
        public newsRequest()
        {
            this.user = new User();
            this.post = new News();
        }
    }
}