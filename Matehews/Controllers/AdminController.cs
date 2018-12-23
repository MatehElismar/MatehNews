using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Matehews.Models;
using Services;
using System.IO;
using Microsoft.AspNetCore.Hosting;
namespace Matehews.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHostingEnvironment env;
        public AdminController(IHostingEnvironment env)
        {
            this.env = env;
        }
        public IActionResult CPanel( )
        {  
            return View( ); 
        } 

         public IActionResult Users()
        {
             ViewData["AccessKeys"] = AccountService.GetAccessKeys();
            //  ViewData["UserStadists"] = AccountService.GetUserStadists();
            AccountService.GenerateStadists();
            ViewBag.total = UserStatist.total;
            ViewBag.common = UserStatist.common;
            ViewBag.admin = UserStatist.admin;
            ViewBag.reporter = UserStatist.reporter;
            ViewBag.enabled = UserStatist.enabled;
            ViewBag.disabled = UserStatist.disabled;
            return View();
        }


        public IActionResult AddNews()
        {
            ViewBag.Categories = PostService.SelectCategories(); 
            ViewData["Title"] = "Agregar Publicacion";
            ViewData["mode"] = "insert";
            ViewData["Post_status"] = PostService.GetPostStatus();
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
            ViewData["Post_status"] = PostService.GetPostStatus();

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
        public IActionResult AddPost(News form)
        { 
            if(AccountService.GetUserByID(form.userID) != null && form.userAccessKey < 102)
            { 
                        if(form.portrait != null)
                    {
                        form.ImgUrl = "posts/"+form.title+form.portrait.FileName;
                        var path = string.Format("{0}/{1}/{2}",env.WebRootPath,"posts", form.title+form.portrait.FileName);
                        using (var s = System.IO.File.Create(path)) 
                        {
                            form.portrait.CopyTo(s);
                        }

                    }
                var postsResults = PostService.AddPost(form);
                
                return Json(postsResults);
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
        public IActionResult UpdatePost(News form)
        {
            if(AccountService.GetUserByID(form.userID) != null && form.userAccessKey < 102)
            { 
                        if(form.portrait != null)
                    {
                        form.ImgUrl = "posts/"+form.title+form.portrait.FileName;
                        var path = string.Format("{0}/{1}/{2}",env.WebRootPath,"posts", form.title+form.portrait.FileName);
                        using (var s = System.IO.File.Create(path)) 
                        {
                            form.portrait.CopyTo(s);
                        }

                    }
                Debug.WriteLine("Param is OK"); 
                
                return Json(PostService.UpdatePost(form)); 
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