using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyPlace.Data;
using MyPlace.Models;
using MyPlace.Repositories.Interfaces;

namespace MyPlace.Repositories
{
    public class PostRepository:IPostRepository

    {
        private readonly PostManagementDbContext Context;
        public PostRepository(PostManagementDbContext Context)
        {
            this.Context = Context;
        }

        public List<Post> GetAll() 
        {
            return Context.Posts.ToList();
        }

        public Post GetByUserId(string userId) 
        {
            return Context.Posts.FirstOrDefault(x => x.UserId == userId);
        }

        public Post GetById(int id)
        {
            return Context.Posts.FirstOrDefault(x => x.Id == id);
        }
        public List<Post> GetByIds(string userId)
        {
            var posts = new List<Post>();
            foreach (var post in Context.Posts.ToList()) 
            {
                if (post.UserId == userId)
                    {
                    posts.Add(post);
                }
            }
            return posts;
        }

        public void Create(Post post) 
        {
            Context.Posts.Add(post);
            Context.SaveChanges();
        }

        public void Delete(Post post)
        {
            Context.Posts.Remove(post);
            Context.SaveChanges();
        }

        public void Update(Post post) 
        {
            Context.Posts.Update(post);
            Context.SaveChanges();
        }
    }
}
