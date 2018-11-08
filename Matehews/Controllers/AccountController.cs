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
            form.id = Program.users.Count +1 ;
            Program.users.Add(form);
            return Json(form);  
        }

        [HttpPost]
        public IActionResult Login(User form)
        {  

            var user = Program.users.Find(x => x.id == form.id);
            if(form.email == user.email && form.pass == user.pass)
            {
                user = Program.users.Find(x => x.id == form.id);
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
        public bool Logout([FromBody]User form)
        {
            var user = Program.users.Find(x => x.id == form.id);
            if(user != null)
            {
                if(user.email == form.email){
                    Program.users.RemoveAt(Program.users.FindIndex(x => x.id == form.id));
                    return true;
                }
            } 
            return false;   
        }
        
        [HttpPost]
        public string IsLogged(User form)
        {
            if(Program.users.Find(x => x.id == form.id) != null)
            {
               return "logged"; 
            }
            return "false"; 
        }
    }
}
