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
        public List<User> users{ get; set;} 
    
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
            form.Logged = true;
            this.users.Add(form);
            return Json(form);
        }

        [HttpPost]
        public IActionResult Login(User form)
        { 
            var user = this.users.Find(x => x.ID = form.ID);
            if(form.Email == user.Email && form.Pass == user.Pass)
            {
                user = this.users.Find(x => x.ID = form.ID).Logged = true;
            }
            else
            {
                user = new User();
                user.Logged = false;
            } 
            return Json(user);
        }

         
         [HttpPost]
        public string Logout(User form)
        {
            if(this.user.Email == form.Email){
                this.user.Logged = false;
                return "isLogout"; 
            }
            return "false"; 
        }
        
        [HttpPost]
        public string IsLogged(User form)
        {
            if(this.users.Find(x => x.ID == form.ID)
            {
               return "logged"; 
            }
            return "false"; 
        }
    }
}
