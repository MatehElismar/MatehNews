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
            ViewBag.Categories = Program.Categories; 
            return View();
        }

        public IActionResult Sections()
        {
             var categories = PostService.SelectCategories();
            return View(categories);
        }

        [HttpPost]
        public IActionResult AddPost([FromBody]newsRequest response)
        {
            if(AccountService.GetUserByID(response.user.id) != null && response.user.accessKey < 102)
            { 
                response.post.id = Program.Posts.Count + 1;
                response.post.datetimePosted = DateTime.Now;
                
                return Json(PostService.AddPost(response.post));
            }
            return Json(null);
        }

        public IActionResult UpdatePost([FromBody]newsRequest response)
        {
            if(AccountService.GetUserByID(response.user.id) != null && response.user.accessKey < 102)
            { 
                response.post.id = Program.Posts.Count + 1;
                response.post.datetimePosted = DateTime.Now;
                
                return Json(PostService.UpdatePost(response.post));
            }
            return Json(null);
        }

        [HttpPost]
        public IActionResult UpdateSection([FromBody]CategorieRequest response)
        { 
            
             if(AccountService.GetUserByID(response.user.id) != null && response.user.accessKey < 102)
            {  
                
                return Json(PostService.UpdateCategorie(response.categorie, response.lastname ));
            }
            return Json(null);
        } 

         [HttpPost]
        public IActionResult AddSection([FromBody]CategorieRequest response)
        { 
             if(AccountService.GetUserByID(response.user.id) != null && response.user.accessKey < 102)
            {  
                
                return Json(PostService.AddCategorie(response.categorie));
            }
            return Json(null);
        } 

         [HttpPost]
        public IActionResult GetSection([FromBody]string name)
        { 
            var categorie = PostService.FindCategorieByName(name);
            return Json(categorie);
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

      public class CategorieRequest
    {
        public User user{ get; set; }
        public Categorie categorie{ get; set; }

        public string lastname { get; set; }
        public CategorieRequest()
        {
            this.user = new User();
            this.categorie = new Categorie();
        }
    }
}