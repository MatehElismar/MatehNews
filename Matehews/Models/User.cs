using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matehews.Models
{
    public class User
    {
        public int ID { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public bool AccessKey { get; set; }
    }
}
