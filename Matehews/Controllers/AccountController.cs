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
        public IActionResult AddUser(User user)
        {
            Debug.WriteLine("Nombre" + user.Email);
            if (AccountService.Register(user))
            {
                return StatusCode(200);
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}