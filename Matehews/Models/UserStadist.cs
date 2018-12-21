using System;
using System.Collections.Generic;

namespace Matehews.Models
{
    public class UserStatist
    {
        public static int total {get{
            return common + reporter + admin;
        }}
        public static int common {get; set;}
        public static int admin {get; set;}
        public static int reporter {get; set;}  

        public static int enabled{get; set;}
        public static int disabled{get; set;}
    }
}