﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Matehews.Models;

namespace Matehews.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index(User user = null)
        {   

            return View(user);
        }
 
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            var user = new User();  
            return View(user);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            var user = new User();  
            return View(user);
        }

        public IActionResult Privacy()
        {
            var user = new User();  
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
