using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MyPlace.Models;

namespace MyPlace.ViewModels
{
    public class DetailsViewModel
    {

        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public bool isPublic { get; set; }
        [Required]
      
        public string UserId { get; set; }



    }
}
