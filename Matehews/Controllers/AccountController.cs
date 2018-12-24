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

        public IActionResult Profile(int id)
        {
            var user = AccountService.GetUserProfileByID(id);
            return View( user );
        } 

        [HttpPost]
         public IActionResult AboutMe([FromBody]UserProfile profile)
        {
            
            if(AccountService.GetUserByID(profile.id) != null)
            { 
              var user = AccountService.UpdateProfile(profile);
            return Json( user );
            }
            return Json(null);
            
        } 


        [HttpPost]
        public IActionResult Register(User form)
        { 
            // form.id = Program.users.Count + 1;
            // Program.users.Add(form);
            if(ValidUser())
            {
                if(AccountService.Register(form))
                {
                    var callBackUser = AccountService.GetLastUserRegistred();
                    callBackUser.logged = true;
                    Program.Logs.Add(callBackUser);//lo logeamos
                    return Json(callBackUser);
                }
                else
                {
                    Json("Hubon problemas con la base de datos;");
                }
            }
            return Json("el usuario no es valido");  
        }

        [HttpPost]
        public IActionResult Login(User form)
        {   
            var user = AccountService.GetUserByEmail(form.email);
            if(user != null)
            {
                  if(Program.Logs.Find(x => x.id == user.id) != null)
                {
                    //Ya esta logeado
                     user.logged = true;
                    return Json(user);
                }
                else if(form.email == user.email && form.pass == user.pass)
                {
                   //lo agregamos a la lista de logs
                    Program.Logs.Add(user);
                    user.logged = true;
                }
            } 
            else
            {
                user = new User();
                user.first = "Credenciales incorrectas";
                user.logged = false; 
            } 
            return Json(user);
        }

         
         [HttpPost]
        public bool Logout([FromBody]User form)
        {
            if(form == null) {return false;} 
            var user = Program.Logs.Find(x => x.id == form.id);
            if(user != null)
            {
                if(user.email == form.email){
                    Program.Logs.Remove(Program.users.Find(x => x.id == form.id));
                    return true;
                }
            } 
            return false;   
        }
         
        [HttpPost]
        public bool IsLogged([FromBody]User form)
        {
            if(form == null){ return false;}
            if(Program.Logs.Find(x => x.id == form.id) != null)
            {
               return true;   
            }
            return false; 
        }

        private bool ValidUser()
        {
            return true;
        }

        // ##########ADMIN#######
        public ActionResult AddUsers(){
            ViewData["AccessKeys"] = AccountService.GetAccessKeys();
            Debug.WriteLine(ViewData["AccessKeys"]);
            return View();
        }

        [HttpPost]
        public ActionResult AddUser([FromBody]userRequest form){
            if(AccountService.GetUserByID(form.admin.id) != null && form.admin.accessKey == 100)
            { 
              var user = AccountService.Register(form.user);
              return Json( user );
            }
            return Json(null);
        }

        

        [HttpGet]
        public ActionResult GetAdministrativeUsers()
        {
            return Json(AccountService.SelectAdministrativeUsers());
        }

        [HttpGet]
        public ActionResult GetAccessKeys()
        {
            return Json(AccountService.GetAccessKeys());
        }
    }
}
