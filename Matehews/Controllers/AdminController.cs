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
        public IActionResult CPanel(User user = null)
        { 
            
            return View(user);
        }

        public IActionResult ManageUsers()
        {
            var user = new User();  
            return View(user);
        }

        public IActionResult AddNews()
        {
            var user = new User();  
            return View(user);
        }

        public IActionResult AddSections()
        {
            var user = new User();  
            return View(user);
        }

        public IActionResult RemoveNews()
        {
            var user = new User();  
            return View(user);
        } 
    }
}