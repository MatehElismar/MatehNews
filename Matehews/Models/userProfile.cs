using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matehews.Models
{
    public class UserProfile : User
    { 

        public override string fullName{get; set;}
        public string aboutMe {get; set;}
        public string access{get; set;}
        public UserProfile()
        { 
        }
    }
}
