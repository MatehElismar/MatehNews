using System;
using System.Collections.Generic;
using System.Linq; 
using System.Web;
using Matehews.Models;
using System.Diagnostics;
using System.Data;

namespace Services
{ 
    public class CommentService
    {  
        public CommentService()
        { 
        }

        public static int AddComment(Comment comment)
        {
            var c = new Server();
            var p = new List<DbParameter>();
            p.Add(new DbParameter("id", comment.id, ParameterDirection.Output)); 
            p.Add(new DbParameter("postID", comment.postID)); 
            p.Add(new DbParameter("userID", comment.user.id));  
            p.Add(new DbParameter("content", comment.content));  
            var res = c.InsertOrUpdate("addComment", p);   
            return (res) ? c.Id : -1;
        }

         public static int AddReplieToComment(Comment comment)
        {
            var c = new Server();
            var p = new List<DbParameter>();
            p.Add(new DbParameter("id", comment.id, ParameterDirection.Output)); //Comentario al cual se le va a responder 
            p.Add(new DbParameter("userID", comment.user.id));  
            p.Add(new DbParameter("content", comment.content));  
            var res = c.InsertOrUpdate("addReplieToComment", p);  
            return (res) ? c.Id : -1;
        }

         public static bool LikeComment(int commentId)
        {
            var c = new Server();
            var p = new List<DbParameter>();
            p.Add(new DbParameter("commentID", commentId)); 
            var res = c.InsertOrUpdate("likeComment", p);  
            return res;
        }

        public static bool LikeReplie(int replieId)
        {
            var c = new Server();
            var p = new List<DbParameter>();
            p.Add(new DbParameter("replieID", replieId)); 
            var res = c.InsertOrUpdate("likeReplie", p);  
            return res;
        }

        public static List<Comment> GetComments(int postID)
        {
            var c = new Server(); 
           var p = new List<DbParameter>();
           p.Add(new DbParameter("postID", postID));
           var reader = c.QueryList("getComments", p); 
           var list = new List<Comment>();
            while (reader.Read())
            { 
                var cat = new Comment();
                cat.id = Convert.ToInt32(reader["id"]); 
                cat.user.id = Convert.ToInt32(reader["userID"]); 
                cat.user.username = reader["username"].ToString(); 
                cat.likes = Convert.ToInt32(reader["likes"]); 
                cat.postID = Convert.ToInt32(reader["postID"]); 
                cat.content = reader["content"].ToString();
                list.Add(cat);

            }
            c.Close();
            return list;
        }

         public static List<Comment> GetRepliesToComment()
        {
            var c = new Server(); 
           
           var reader = c.QueryList("getRepliesToComment", null);
           Debug.WriteLine(c.Msg);
            var list = new List<Comment>();
            while (reader.Read())
            { 
                var cat = new Comment();
                cat.id = Convert.ToInt32(reader["id"]); 
                cat.user.id = Convert.ToInt32(reader["userID"]); 
                cat.user.username = reader["username"].ToString(); 
                cat.likes = Convert.ToInt32(reader["likes"]); 
                cat.postID = Convert.ToInt32(reader["commentID"]); //Comentario al que pertenece
                cat.content = reader["content"].ToString();
                list.Add(cat);
            }
            c.Close();
            return list;
        }

         public static int GetCountOfComments(int postID)
        {
            var c = new Server();
            var p = new List<DbParameter>();
            p.Add(new DbParameter("postID", postID));
           var reader = c.QueryList("getCountOfComments", p);
            if (reader.Read())
            { 
                var cat = new Comment();
                return Convert.ToInt32(reader["commentsCount"]);
            }
            c.Close();
            return 0;
        }

    }
}