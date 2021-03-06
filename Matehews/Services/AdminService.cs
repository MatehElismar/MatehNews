﻿using System;
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
    public class AdminService
    {
        public static string Msg;
        public AdminService()
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