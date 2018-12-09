using System;
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
        public string content { get; set; }
        
        public News( )
        { 
            this.ImgUrl = ImgUrl;
            this.title = title;
            this.content = content;
        }
        public News(string title, string content, string ImgUrl = "")
        { 
            this.ImgUrl = ImgUrl;
            this.title = title;
            this.content = content;
        }
    }
}
