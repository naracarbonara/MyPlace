using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MyPlace.ViewModels
{
    public class EditViewModel
    {
        public int Id { get; set; }

     
        public bool isPublic { get; set; }

      public string ImageUrl { get; set; }
      public DateTime DateCreated { get; set; }
        public IdentityUser User { get; set; }
        public string UserId { get; set; }


    }
}
