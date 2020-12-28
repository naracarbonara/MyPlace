using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyPlace.Models;
using MyPlace.Repositories.Interfaces;
using MyPlace.Services.Interfaces;

namespace MyPlace.Services
{
    public class PostService:IPostService
    {
        private readonly IPostRepository PostRepository;
        public PostService(IPostRepository PostRepository)
        {
            this.PostRepository = PostRepository;
        }

        public List<Post> GetAll() 
        {
            return PostRepository.GetAll();
        }

        public Post GetByUserId(string userId) 
        {
            return PostRepository.GetByUserId(userId);
        }

        public Post GetById(int id)
        {
            return PostRepository.GetById(id);
        }

        public void Create(string userId, string username, string imageUrl, bool isPublic) 
        {
            Post post = new Post();
            post.ImageUrl = imageUrl;
            post.UserId = userId;
            post.UserName = username;
            post.DateCreated = DateTime.Now;
            post.isPublic = isPublic;
            PostRepository.Create(post);
        }

        public void Delete (Post post)
        {
            PostRepository.Delete(post);
        }

        public void Edit(Post post)     
        {
            PostRepository.Update(post);
        }

        public List<Post> GetByIds(string id) 
        {
            return PostRepository.GetByIds(id);
        }
    }
}
