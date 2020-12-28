using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyPlace.Models;

namespace MyPlace.Services.Interfaces
{
   public interface IPostService
    {
        List<Post> GetAll();

  Post GetByUserId(string userId);
    
        void Delete(Post post);
        void Create(string userId, string username, string imageUrl, bool isPublic);
        void Edit(Post post);
        List<Post> GetByIds(string id);
        Post GetById(int id);
    }
}
