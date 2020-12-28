using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MyPlace.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public bool isPublic { get; set; }
        [Required]
        public IdentityUser User { get; set; }
        public string UserId { get; set; }

        public string UserName { get; set; } 


    }
}
