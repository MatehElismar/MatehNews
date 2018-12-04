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
        public IActionResult Register()
        {
             var user = new User();  
             
             return View(user);
        }

        public IActionResult Login()
        {
            var user = new User();
            return View(user);
        } 

         [HttpPost]
        public IActionResult Register(User user)
        {
            
        //     AccountService.Register(user);
        //    return AccountService.Msg; 

            user = new User();
            user.Logged = true;
            return RedirectToAction("Index", "Home", user);
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
        //     Debug.WriteLine("Nombre: " + user.Email);
        //     AccountService.Login(user.Username, user.Pass);
        //    return AccountService.Msg;
                user = new User(); 

            if(user.AccessKey == 100){
                user.Logged = true;
                return RedirectToAction("CPanel", "Admin", user);
            }
            else{
                user.Logged = true;
                return RedirectToAction("Index", "Home", user); 
            }

        }

         [HttpGet]
        public IActionResult Logout(User user)
        {
            return RedirectToAction("Index", "Home"); 
        }
    }
}