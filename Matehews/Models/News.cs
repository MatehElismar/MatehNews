﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace Matehews.Models 
{  
    public class News 
    {
        public string ImgUrl{ get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string review { get; set; }
        public string content { get; set; }
        public string categorieName {get; set;}
        public string author { get; set; }
        public DateTime datetimePosted { get; set; }  
        public string url { 
            get{
                return title.Replace(' ', '-');
            }
        }
        
        public News( )
        { 
            this.datetimePosted = new DateTime();
            this.ImgUrl = ImgUrl;
            this.title = title;
            this.content = content;
            this.author = "Mateh Elismar";
        }
        public News(string title, string review, string categorieName, string ImgUrl = "")
        { 
            this.datetimePosted = new DateTime();
            this.ImgUrl = ImgUrl;
            this.title = title;
            this.review = review;
            this.categorieName = categorieName;
            this.author = "Mateh Elismar";
            this.content = review; 
        }
    }
}
