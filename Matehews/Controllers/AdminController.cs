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
        public IActionResult CPanel()
        {
            return View();
        }

        public IActionResult ManageUsers()
        {
            return View();
        }

        public IActionResult AddNews()
        {
            return View();
        }

        public IActionResult AddSections()
        {
            return View();
        }

        public IActionResult RemoveNews()
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