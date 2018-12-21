using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Matehews.Models;
using Services;

namespace Matehews.Controllers
{ 
    public class PostController : Controller
    {
        
        [HttpPost]
        public ActionResult AddComment([FromBody]Comment comment)
        {
            return Json(CommentService.AddComment(comment));
        }

        [HttpPost]
        public ActionResult AddReplie([FromBody]Comment comment)
        {
            return Json(CommentService.AddReplieToComment(comment));
        }

        [HttpPost]
        public ActionResult LikeComment(int commentID)
        {
            return Json(CommentService.LikeComment(commentID));
        }

        [HttpPost]
        public ActionResult LikeReplie([FromBody]int commentID)
        {
            return Json(CommentService.LikeReplie(commentID));
        }
    }
}
