using System;
using System.Collections.Generic;
using System.Linq; 
using System.Web;
using Matehews.Models;

/// <summary>
/// Summary description for Binding
/// </summary>
/// 
 namespace Services
{ 
    public class AccountService
    {
        public static string Msg;
        public AccountService()
        {
        }

        public static bool Register(User u)
        {
            var c = new Server();
            var p = new List<DbParameter>();
            p.Add(new DbParameter("Username", u.username)); 
            p.Add(new DbParameter("Pass", u.pass)); 
            p.Add(new DbParameter("FirstName", u.first)); 
            p.Add(new DbParameter("LastName", u.last)); 
            p.Add(new DbParameter("AccessKey", u.accessKey)); 
            p.Add(new DbParameter("Email", u.email)); 
            p.Add(new DbParameter("DateRegistred", u.DateRegistred)); 
            p.Add(new DbParameter("Msg", "", System.Data.ParameterDirection.Output)); 
            var res = c.InsertOrUpdate("AddUser", p);
            Msg = c.Msg;
            return res;
        }

           public static UserProfile UpdateProfile(UserProfile u)
        {
            var c = new Server();
            var p = new List<DbParameter>();
            p.Add(new DbParameter("AboutMe", u.aboutMe));  
            p.Add(new DbParameter("userID", u.id));  
            var res = c.InsertOrUpdate("updateProfile", p);
            Msg = c.Msg;
            if(res){
                return GetUserProfileByID(u.id);
            }
            return null;
        }

        public static string Login(string user, string pass)
        {
            var c = new Server();
            var p = new List<DbParameter>();

            p.Add(new DbParameter("Username", user));
            p.Add(new DbParameter("Pass", pass));

           
           var reader = c.QueryList("Login", p);
            if (reader.Read())
            {
                return "logged";
            }
            return "no logged";
        }

          public static User GetLastUserRegistred( )
        {
            var c = new Server(); 

           
           var reader = c.QueryList("GetLastUserRegistred", null);
            var u = new User();
            if (reader.Read())
            {
                u.id = Convert.ToInt32(reader["id"]); 
                u.first = reader["FirstName"].ToString(); 
                u.last = reader["LastName"].ToString(); 
                u.username = reader["Username"].ToString(); 
                u.pass = reader["Pass"].ToString(); 
                u.email = reader["Email"].ToString(); 
                u.accessKey = Convert.ToInt32(reader["AccessKey"]); 
                u.DateRegistred = Convert.ToDateTime(reader["DateRegistred"]); 
                return u;
            }
            return null;
        }

        public static User GetUserByID(int id)
        {
            var c = new Server(); 
            var p = new List<DbParameter>();
            p.Add(new DbParameter("id", id));
           
           var reader = c.QueryList("GetUserByID", p);
            var u = new User();
            if (reader.Read())
            {
                u.id = Convert.ToInt32(reader["Id"]); 
                u.first = reader["FirstName"].ToString(); 
                u.last = reader["LastName"].ToString(); 
                u.username = reader["Username"].ToString(); 
                u.pass = reader["Pass"].ToString(); 
                u.email = reader["Email"].ToString(); 
                u.accessKey = Convert.ToInt32(reader["AccessKey"]); 
                u.DateRegistred = Convert.ToDateTime(reader["DateRegistred"]); 
                return u;
            }
            return null;
        }

        public static UserProfile GetUserProfileByID(int id)
        {
            var c = new Server(); 
            var p = new List<DbParameter>();
            p.Add(new DbParameter("userID", id));
           
           var reader = c.QueryList("getUserProfile", p);
            var u = new UserProfile();
            if (reader.Read())
            {
                u.id = Convert.ToInt32(reader["id"]);  
                u.fullName = reader["fullName"].ToString(); 
                u.aboutMe = reader["aboutMe"].ToString(); 
                u.email = reader["Email"].ToString(); 
                u.access = (reader["access"]).ToString(); 
                u.DateRegistred = Convert.ToDateTime(reader["DateRegistred"]); 
                u.cantPosts = Convert.ToInt32(reader["cantPosts"]); 
                return u;
            }
            return null;
        }

        public static List<User> SelectAdministrativeUsers()
        {
            var c = new Server(); 
            var p = new List<DbParameter>(); 
           
           var reader = c.QueryList("SelectAdministrativeUsers", null);
            var u = new User();
            var list = new List<User>();
            if (reader.Read())
            {
                u.id = Convert.ToInt32(reader["Id"]); 
                u.first = reader["FirstName"].ToString(); 
                u.last = reader["LastName"].ToString(); 
                u.username = reader["Username"].ToString(); 
                u.pass = reader["Pass"].ToString(); 
                u.email = reader["Email"].ToString(); 
                u.accessKey = Convert.ToInt32(reader["AccessKey"]); 
                u.DateRegistred = Convert.ToDateTime(reader["DateRegistred"]); 
                u.cantPosts = Convert.ToInt32(reader["publicaciones"]); 
                list.Add(u);
            }
            return list;
        }

        public static User GetUserByEmail(string email)
        {
            var c = new Server(); 
            var p = new List<DbParameter>();
            p.Add(new DbParameter("email", email));
           
           var reader = c.QueryList("GetUserByEmail", p);
            var u = new User();
            if (reader.Read())
            {
                u.id = Convert.ToInt32(reader["Id"]); 
                u.first = reader["FirstName"].ToString(); 
                u.last = reader["LastName"].ToString(); 
                u.username = reader["Username"].ToString(); 
                u.pass = reader["Pass"].ToString(); 
                u.email = reader["Email"].ToString(); 
                u.accessKey = Convert.ToInt32(reader["AccessKey"]); 
                u.DateRegistred = Convert.ToDateTime(reader["DateRegistred"]); 
                return u;
            }
            return null;
        }

         public static List<AuxiliarTable> GetAccessKeys()
        {
            var c = new Server();   
           
           var reader = c.QueryList("getAccessKeys", null);
            var l = new List<AuxiliarTable>();
            while(reader.Read())
            {
                var u = new AuxiliarTable();
                u.id = Convert.ToInt32(reader["Id"]); 
                u.description = reader["name"].ToString();  
                l.Add(u);
            }
            return l;
        }

        public static List<AuxiliarTable> GetUserStadists()
        {
            var c = new Server();   
           
           var reader = c.QueryList("getUserStadists", null);
            var l = new List<AuxiliarTable>();
            while(reader.Read())
            {
                if(reader["categorie"].ToString().ToLower() == "admin")
                    UserStatist.admin = Convert.ToInt32(reader["cantidad"]);

                if(reader["categorie"].ToString().ToLower() == "reporter")
                    UserStatist.reporter = Convert.ToInt32(reader["cantidad"]);

                if(reader["categorie"].ToString().ToLower() == "user")
                    UserStatist.common = Convert.ToInt32(reader["cantidad"]);

            }
            return l;
        }

          public static List<AuxiliarTable> GetUsersStatus()
        {
            var c = new Server();   
           
           var reader = c.QueryList("get_users_status", null);
            var l = new List<AuxiliarTable>();
            while(reader.Read())
            {
                if(Convert.ToInt32(reader["status"]) == 1)
                    UserStatist.enabled = Convert.ToInt32(reader["cantidad"]);
                else
                    UserStatist.disabled = Convert.ToInt32(reader["cantidad"]);
            }
            return l;
        }


        public static void GenerateStadists()
        {
            GetUserStadists();
            GetUsersStatus();
        }

    }
}