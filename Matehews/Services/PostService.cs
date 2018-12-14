using System;
using System.Collections.Generic;
using System.Linq; 
using System.Web;
using Matehews.Models;
using System.Diagnostics;

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
            p.Add(new DbParameter("imgUrl", "post.ImgUrl"));  
            p.Add(new DbParameter("title", post.title.ToLower())); 
            p.Add(new DbParameter("review", post.review)); 
            p.Add(new DbParameter("content", post.content)); 
            p.Add(new DbParameter("categorieName", post.categorieName)); 
            p.Add(new DbParameter("idAuthor", post.author));  
            p.Add(new DbParameter("datetimePosted", "12/12/12"));  
            var res = c.InsertOrUpdate("AddPost", p); 
            Debug.WriteLine(c.Msg);
            return res;
        }

         public static bool UpdatePost(News post)
        {
            var c = new Server();
            var p = new List<DbParameter>();
            p.Add(new DbParameter("imgUrl", "post.ImgUrl")); 
            p.Add(new DbParameter("id", post.id)); 
            p.Add(new DbParameter("title", post.title.ToLower())); 
            p.Add(new DbParameter("review", post.review)); 
            p.Add(new DbParameter("content", post.content)); 
            p.Add(new DbParameter("categorieName", post.categorieName)); 
            p.Add(new DbParameter("idAuthor", post.author));  
            p.Add(new DbParameter("datetimePosted","12/12/12"));  
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
                cat.description = reader["description"].ToString();
                return cat;
            }
            return null;
        }

        public static List<Categorie> SelectCategories()
        {
            var c = new Server(); 
           
           var reader = c.QueryList("getCategories", null);
           Debug.WriteLine(c.Msg);
           var list = new List<Categorie>();
            while (reader.Read())
            { 
                var cat = new Categorie();
                cat.name = reader["name"].ToString(); 
                cat.description = reader["description"].ToString();
                list.Add(cat);

            }
            return list;
        }

          public static News GetPost(string title)
        {
            title = title.Replace("-"," ");
            title = title.ToLower();
            var c = new Server(); 
            var p = new List<DbParameter>();
           p.Add(new DbParameter("title", title));
           var reader = c.QueryList("GetPost", p);
           Debug.WriteLine(c.Msg);
           var cat = new Categorie();  
            if (reader.Read())
            {   
                 var post = new News();
                post.title = reader["title"].ToString();
                post.review = reader["review"].ToString();
                post.content = reader["content"].ToString();
                post.categorieName = reader["categorieName"].ToString();
                post.author = reader["author"].ToString();
                post.datetimePosted = Convert.ToDateTime(reader["datetimePosted"]);
                return post; 
            }
            return null;
        }


        public static List<News> GetTopOfPosts(int top)
        {
            var c = new Server(); 
           var p = new List<DbParameter>();
           p.Add(new DbParameter("top", top));
           var reader = c.QueryList("GetTopOfPosts", p);
           Debug.WriteLine(c.Msg); 
           var list = new List<News>();
           var count = 0;
            while (reader.Read())
            {   
                // if(count < top)
                // { 
                    var post = new News();
                    post.title = reader["title"].ToString();
                    post.review = reader["review"].ToString();
                    post.content = reader["content"].ToString();
                    post.categorieName = reader["categorieName"].ToString();
                    post.author = reader["author"].ToString();
                    post.datetimePosted = Convert.ToDateTime(reader["datetimePosted"]);
                    list.Add(post);
                    count++;
                // }
                // else {
                //     list.Reverse();
                //     Console.WriteLine(list.Count);
                //     return list;}
            }
            list.Reverse();
            return list;
        }

        
        public static List<News> GetTopReviews(string name, int top)
        {
            var c = new Server(); 
           var p = new List<DbParameter>();
           p.Add(new DbParameter("categorieName", name));
           p.Add(new DbParameter("top", top));
           var reader = c.QueryList("GetTopReviews", p);
           Debug.WriteLine(c.Msg); 
           var l = new List<News>();
            while (reader.Read())
            {   var post = new News();
                post.title = reader["title"].ToString();
                post.review = reader["review"].ToString(); 
                l.Add(post);
            }
            l.Reverse();
            return l;
        }


        public static bool AddCategorie(Categorie cat)
        {
            var c = new Server();
            var p = new List<DbParameter>();
            p.Add(new DbParameter("name", cat.name));  
            p.Add(new DbParameter("description", cat.description));  
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
            var res = c.InsertOrUpdate("UpdateCategorie", p);  
            return res;
        }
    }
}