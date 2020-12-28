using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyPlace.Models;
using MyPlace.ViewModels;

namespace MyPlace.Helpers
{
    public  static class ModelConverter
    {
        public static PostViewModel ToOverviewViewModel(this Post post)
        {
            return new PostViewModel
            {
                Id = post.Id,
                ImageUrl = post.ImageUrl,
                DateCreated = post.DateCreated,
                isPublic = post.isPublic,
                UserId = post.UserId,
                UserName=post.UserName
            };
        }


        public static DetailsViewModel ToDetailsViewModel(this Post post)
        {
            return new DetailsViewModel()
            {
                Id = post.Id,
                ImageUrl = post.ImageUrl,
                DateCreated = post.DateCreated,
                isPublic = post.isPublic,
                UserId = post.UserId
            };






    }

        public static Post ToPostModel(PostViewModel viwModel)
        {
            return new Post()
            {
                Id = viwModel.Id,
                ImageUrl = viwModel.ImageUrl,
                DateCreated = viwModel.DateCreated,
                isPublic = viwModel.isPublic,
                UserId = viwModel.UserId
            };
        }



            public static EditViewModel ToEditViewModel(Post post)
            {
            return new EditViewModel()
            {
                isPublic = post.isPublic,
                Id= post.Id,
                ImageUrl = post.ImageUrl,
                DateCreated = post.DateCreated,
                UserId = post.UserId,
                User=post.User

            };

            }



        public static Post FromEditViewModel(EditViewModel editviewModel)
        {
            return new Post()
            {
                isPublic = editviewModel.isPublic,
                ImageUrl=editviewModel.ImageUrl,
                DateCreated=editviewModel.DateCreated,
                UserId=editviewModel.UserId,
                Id=editviewModel.Id,

            };

        }
    }
}
