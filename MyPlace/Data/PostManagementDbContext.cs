using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyPlace.Models;

namespace MyPlace.Data
{
    public class PostManagementDbContext : IdentityDbContext
    {
        public PostManagementDbContext(DbContextOptions<PostManagementDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Post> Posts { get; set; }
    }
}
