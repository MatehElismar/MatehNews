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
            ViewBag.Categories = PostService.SelectCategories(); 
            ViewData["Title"] = "Agregar Publicacion";
            ViewData["mode"] = "insert";
             ViewBag.Post = new News();
            return View();
        }

        [HttpGet]
         public IActionResult UpdatePost(string title)
        {
            ViewBag.Categories = PostService.SelectCategories(); 
            ViewData["Title"] = "Actualizar Publicacion";
            ViewBag.Post = PostService.GetPost(title);
            ViewData["mode"] = "update";

            return View("AddNews");
        }

        public IActionResult UpdateNews()
        {
            ViewBag.Users = AccountService.SelectAdministrativeUsers(); 
            return View();
        }


        public IActionResult Sections()
        {
             var categories = PostService.SelectCategories();
            return View(categories);    
        }

        [HttpPost]
        public IActionResult AddPost([FromBody]newsRequest request)
        {
            if(AccountService.GetUserByID(request.user.id) != null && request.user.accessKey < 102)
            { 
                request.post.id = Program.Posts.Count + 1;
                request.post.datetimePosted = DateTime.Now;
                
                return Json(PostService.AddPost(request.post));
            }
            return Json(null);
        }

      [HttpPost]
        public IActionResult SearchPosts([FromBody]newsRequest data)
        {
            if(AccountService.GetUserByID(data.user.id) != null && data.user.accessKey < 102)
            { 
                var postsResults = PostService.SearchPosts(data.post);
                
                return Json(postsResults);
            }
            return Json(null);
        }

        [HttpPost]
        public IActionResult Actualizar([FromBody]newsRequest body)
        {
            if(AccountService.GetUserByID(body.user.id) != null && body.user.accessKey < 102)
            { 
                Debug.WriteLine("Param is OK");

                body.post.id = Program.Posts.Count + 1;
                body.post.datetimePosted = DateTime.Now;
                
                return Json(PostService.UpdatePost(body.post));
            }
            Debug.WriteLine("Param is null"); 
            return Json(null);
        }

        [HttpPost]
        public IActionResult UpdateSection([FromBody]CategorieRequest request)
        { 
            
             if(AccountService.GetUserByID(request.user.id) != null && request.user.accessKey < 102)
            {  
                
                return Json(PostService.UpdateCategorie(request.categorie, request.lastname ));
            }
            return Json(null);
        } 

         [HttpPost]
        public IActionResult AddSection([FromBody]CategorieRequest request)
        { 
             if(AccountService.GetUserByID(request.user.id) != null && request.user.accessKey < 102)
            {  
                
                return Json(PostService.AddCategorie(request.categorie));
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
}