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
        public User user{ get; set;} 
    
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
            this.user = form;
            this.user.Logged = true;
            return Json(this.user);
        }

        [HttpPost]
        public IActionResult Login(User form)
        {
            this.user = form;
            this.user.Logged = true;
            return Json(this.user);
        }

         
         [HttpPost]
        public bool Logout(User form)
        {
            if(this.user.Email == form.Email){
                this.user.Logged = false;
                return (true); 
            }
            return (false); 
        }
    }
}