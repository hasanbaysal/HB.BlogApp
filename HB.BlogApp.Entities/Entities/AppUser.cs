 using HB.BlogApp.Entities.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.Entities.Entities
{
    public class AppUser : IdentityUser, IBaseEntity
    {

        public string Name { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public string? LastLogin { get; set; }
        public bool isBanned { get; set; } = false;

        public List<UserFavBlog> UserFavBlogs { get; set; } = new();
        public List<Comment> Comments { get; set; } = new();
    }
}
