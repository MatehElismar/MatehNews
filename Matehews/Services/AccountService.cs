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
                u.first = reader["first"].ToString(); 
                u.last = reader["last"].ToString(); 
                u.username = reader["username"].ToString(); 
                u.pass = reader["pass"].ToString(); 
                u.email = reader["email"].ToString(); 
                u.accessKey = Convert.ToInt32(reader["accessKey"]); 
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
    }
}