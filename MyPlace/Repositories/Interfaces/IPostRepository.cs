using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyPlace.Models;

namespace MyPlace.Repositories.Interfaces
{
  public  interface IPostRepository
    {
        List<Post> GetAll();
        Post GetByUserId(string userId);
        void Create(Post post) ;
        void Delete(Post post);
        void Update(Post post);
        List<Post> GetByIds(string userId);

        Post GetById(int id);
    }
}
