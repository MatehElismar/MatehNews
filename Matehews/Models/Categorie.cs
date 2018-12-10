using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matehews.Models
{
    public class Categorie
    {  
        public string name { get; set; }
        public int cantPosts { get; set; }
        public string description{ get; set; }
        
        public Categorie( )
        { 
             this.description = "I am a description";
        }
        public Categorie( string name)
        { 
            this.description = "I am a description"; 
            this.name = name; 
        }
    }
}
