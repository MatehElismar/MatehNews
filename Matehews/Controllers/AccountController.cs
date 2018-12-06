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
    public class AccountController : Controller
    {
        
        public static List<User> users{ get; set;} 

        static AccountController()
        {
            AccountController.users = new List<User>();
        }
    
        public IActionResult Register()
        {
              
             
             return View( );
        }

        public IActionResult Login()
        {
           
            return View( );
        } 


        [HttpPost]
        public IActionResult Register(User form)
        { 
            form.logged = true;
            form.id = users.Count +1 ;
            AccountController.users.Add(form);
            return Json(form);  
        }

        [HttpPost]
        public IActionResult Login(User form)
        {  

            var user = AccountController.users.Find(x => x.id == form.id);
            if(form.email == user.email && form.pass == user.pass)
            {
                user = AccountController.users.Find(x => x.id == form.id);
                user.logged = true;
            }
            else
            {
                user = new User();
                user.logged = false;
            } 
            return Json(user);
        }

         
         [HttpPost]
        public IActionResult Logout(User form)
        {
            // var user = AccountController.users.Find(x => x.id == form.id);
            // if(user.email == form.email){
            //     AccountController.users.RemoveAt(AccountController.users.FindIndex(x => x.id == form.id));
            //     return "isLogout";
            // }
            // return "false";  
            return Json(form);
        }
        
        [HttpPost]
        public string IsLogged(User form)
        {
            if(AccountController.users.Find(x => x.id == form.id) != null)
            {
               return "logged"; 
            }
            return "false"; 
        }
    }
}
