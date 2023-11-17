using HB.BlogApp.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.DAL.Contexts
{
    public class AppDbContext:IdentityDbContext<AppUser,AppRole,string>
    {
        //DI Container kayıt
        //dbsetler ekleyeceğim
        //konfigürasyonları tanıtacağım


        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserFavBlog> UserFavBlogs { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> option):base(option)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //bunların konfiglerini kendiniz ayrı dosyalarda yazınız
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //appuser - blog -userfavblog

            builder.Entity<AppUser>().HasMany(x => x.UserFavBlogs).WithOne(x => x.AppUser).HasForeignKey(x => x.UserId);

            builder.Entity<Blog>().HasMany(x => x.UserFavBlogs).WithOne(x => x.Blog).HasForeignKey(x => x.BlogId);


            builder.Entity<UserFavBlog>().HasKey(x => new { x.UserId, x.BlogId });

            //appuser - blog -commnet

            builder.Entity<AppUser>().HasMany(x => x.Comments).WithOne(x => x.AppUser).HasForeignKey(x => x.UserId);
            builder.Entity<Blog>().HasMany(x => x.Comments).WithOne(x => x.Blog).HasForeignKey(x => x.BlogId);




            builder.Entity<Comment>().HasKey(x => x.Id);


            //blog- category

            builder.Entity<Blog>().HasOne(x => x.Category).WithMany(x => x.Blogs).HasForeignKey(x => x.CategoryId);


            base.OnModelCreating(builder);  
        }

    }
}
