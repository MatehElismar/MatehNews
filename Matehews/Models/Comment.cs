using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace Matehews.Models 
{  
    public class Comment 
    { 
        public int id { get; set; }  
        public int postID { get; set; } 
        public int likes { get; set; } 
        public User user { get; set; } 
        public string content { get; set; } 

        public List<Comment> Replies {get; set;}
        
        
        public Comment( )
        { 
            this.Replies  = new List<Comment>();
            this.user = new User();

        }
        public Comment(int userID, int postID, string content)
        {  
            this.Replies  = new List<Comment>();
            this.user = new User();
            this.postID = postID;
            this.content = content;
        }
    }
}
