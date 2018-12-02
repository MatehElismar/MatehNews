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
            p.Add(new DbParameter("Username", u.Username)); 
            p.Add(new DbParameter("Pass", u.Pass)); 
            p.Add(new DbParameter("FirstName", u.First)); 
            p.Add(new DbParameter("LastName", u.Last)); 
            p.Add(new DbParameter("AccessKey", u.AccessKey)); 
            p.Add(new DbParameter("Email", u.Email)); 
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
    }
}