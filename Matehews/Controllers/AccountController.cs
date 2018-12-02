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
            return View();
        }

        public IActionResult Login()
        {
            return View();
        } 

         [HttpPost]
        public string AddUser(User user)
        {
            Debug.WriteLine("Nombre" + user.Email);
            AccountService.Register(user);
           return AccountService.Msg;
        }
    }
}