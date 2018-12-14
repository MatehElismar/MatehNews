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
    public class PostService
    { 
        public PostService()
        {
        }

        public static bool AddPost(News post)
        {
            var c = new Server();
            var p = new List<DbParameter>();
            p.Add(new DbParameter("imgUrl", post.ImgUrl));  
            p.Add(new DbParameter("title", post.title)); 
            p.Add(new DbParameter("review", post.review)); 
            p.Add(new DbParameter("content", post.content)); 
            p.Add(new DbParameter("categorieName", post.categorieName)); 
            p.Add(new DbParameter("author", post.author));  
            p.Add(new DbParameter("datetimePosted", post.datetimePosted));  
            var res = c.InsertOrUpdate("AddPost", p); 
            return res;
        }

         public static bool UpdatePost(News post)
        {
            var c = new Server();
            var p = new List<DbParameter>();
            p.Add(new DbParameter("imgUrl", post.ImgUrl)); 
            p.Add(new DbParameter("id", post.id)); 
            p.Add(new DbParameter("title", post.title)); 
            p.Add(new DbParameter("review", post.review)); 
            p.Add(new DbParameter("content", post.content)); 
            p.Add(new DbParameter("categorieName", post.categorieName)); 
            p.Add(new DbParameter("author", post.author));  
            p.Add(new DbParameter("datetimePosted", post.datetimePosted));  
            var res = c.InsertOrUpdate("UpdatePost", p); 
            return res;
        }

        public static Categorie FindCategorieByName(string name)
        {
            var c = new Server();
            var p = new List<DbParameter>();

            p.Add(new DbParameter("name", name)); 

           
           var reader = c.QueryList("FindCategorieByName", p);
           var cat = new Categorie();
            if (reader.Read())
            { 
                cat.name = reader["name"].ToString();
                cat.cantPosts = Convert.ToInt32(reader["cantPosts"].ToString());
                cat.description = reader["description"].ToString();
                return cat;
            }
            return null;
        }

        public static List<Categorie> SelectCategories()
        {
            var c = new Server(); 
           
           var reader = c.QueryList("getCategories", null);
           var cat = new Categorie();
           var list = new List<Categorie>();
            while (reader.Read())
            { 
                cat.name = reader["name"].ToString();
                cat.cantPosts = Convert.ToInt32(reader["cantPosts"]);
                cat.description = reader["description"].ToString();
                list.Add(cat);

            }
            return list;
        }

        public static bool AddCategorie(Categorie cat)
        {
            var c = new Server();
            var p = new List<DbParameter>();
            p.Add(new DbParameter("name", cat.name));  
            p.Add(new DbParameter("description", cat.description)); 
            p.Add(new DbParameter("cantPosts", cat.cantPosts));  
            var res = c.InsertOrUpdate("AddCategorie", p); 
            return res;
        }

         public static bool UpdateCategorie(Categorie cat, string lastname)
        {
            var c = new Server();
            var p = new List<DbParameter>();
            p.Add(new DbParameter("name", cat.name));  
            p.Add(new DbParameter("lastname", lastname));  
            p.Add(new DbParameter("description", cat.description)); 
            p.Add(new DbParameter("cantPosts", cat.cantPosts));  
            var res = c.InsertOrUpdate("AddCategorie", p); 
            return res;
        }
    }
}