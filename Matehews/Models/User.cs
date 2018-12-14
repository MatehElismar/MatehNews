using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matehews.Models
{
    public class User
    {
        public int id { get; set; }
        public string first { get; set; }
        public string last { get; set; }
        public string username { get; set; }
        public string pass { get; set; }
        public string email { get; set; }
        public int accessKey { get; set; }
        public bool logged { get; set; }
        public DateTime DateRegistred { get; set; }

        public User()
        {
            this.logged = false;
            this.accessKey = 102; 
            this.DateRegistred = DateTime.Now;
        }
    }
}
