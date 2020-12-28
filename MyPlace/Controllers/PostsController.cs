using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyPlace.Models;
using MyPlace.Services.Interfaces;
using MyPlace.Helpers;
using Microsoft.AspNetCore.Identity;
using MyPlace.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace MyPlace.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService PostService;
        private readonly UserManager<IdentityUser> userManager;
        public PostsController(IPostService PostService, UserManager<IdentityUser> userManager)
        {
            this.PostService = PostService;
            this.userManager = userManager;

        }
        public IActionResult Overview()
        {
            var dbPosts = PostService.GetAll();
            var viewModels = dbPosts.Select(x => x.ToOverviewViewModel()).ToList();
            return View(viewModels);
        }

        public IActionResult MyPosts()
        {
            var userId = userManager.GetUserId(User);
            var dbPosts = PostService.GetByIds(userId);
            var viewModels = dbPosts.Select(x => x.ToOverviewViewModel()).ToList();
            return View(viewModels);
        }


        public IActionResult Details(string userId)
        {

            //var post = PostService.GetById(userId);
            var posts = PostService.GetByIds(userId);

            var postModels = posts.Select(x => x.ToDetailsViewModel()).ToList();
            return View(postModels);
        }
        
        [Authorize]
        public IActionResult Create()
        {

            var post = new PostViewModel();

            return View(post);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(PostViewModel postViewModel)
        {
            var post = ModelConverter.ToPostModel(postViewModel);
           
            var userIdd = userManager.GetUserId(User);
            var userName = userManager.GetUserName(User);
            PostService.Create(userIdd, userName, post.ImageUrl, post.isPublic);
            return RedirectToAction("Details", new { userId = userIdd });
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var post = PostService.GetById(id);
            var userIdd = userManager.GetUserId(User);
            //var post = ModelConverter.ToPostModel(postViewModel);
            PostService.Delete(post);


            return RedirectToAction("Details", new { userId = userIdd });
        }

        [Authorize]
        public IActionResult Edit(int id)
        {

            var dbpost = PostService.GetById(id);

            var postmodel = ModelConverter.ToEditViewModel(dbpost);
            //PostService.Edit(post);


            return View(postmodel);
        }


        [Authorize]
        [HttpPost]
        public IActionResult Edit(EditViewModel editViewModel)
        {
            if (ModelState.IsValid) 
            {
                var post = ModelConverter.FromEditViewModel(editViewModel);
                PostService.Edit(post);
                return RedirectToAction("Overview");
            }
          
            //PostService.Edit(post);


            return View(editViewModel);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
