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
        /*
                public static bool Update(User fm)
                {
                    var c = new Server();
                    var p = new List<DbParameter>();
                    p.Add(new DbParameter("Id", fm.Id));
                    p.Add(new DbParameter("nombre", fm.Nombre));
                    p.Add(new DbParameter("apellido", fm.apellido));
                    p.Add(new DbParameter("genero", fm.genero));
                    p.Add(new DbParameter("dia", fm.dia));
                    p.Add(new DbParameter("mes", fm.mes));
                    p.Add(new DbParameter("ano", fm.ano));


                    return c.InsertOrUpdate("UpdateForm", p);
                }

                public static List<Formulario> Search()
                {
                    var c = new Server();
                    var reader = c.QueryList("traemelo", null);
                    var l = new List<Formulario>();
                    if (reader.Read())
                    {
                        var f = new Formulario();
                        f.Nombre = reader["nombre"].ToString();
                        f.apellido = reader["apellido"].ToString();
                        f.genero = reader["genero"].ToString();
                        f.dia = Convert.ToInt32(reader["dia"]);
                        f.mes = Convert.ToInt32(reader["mes"]);
                        f.ano = Convert.ToInt32(reader["año"]);
                        l.Add(f);
                    }
                    return l;
                }
                  */
    }
}