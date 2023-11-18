using HB.BlogApp.BL.Services;
using HB.BlogApp.Dto;
using HB.BlogApp.Dto.RoleDtos;
using HB.BlogApp.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.BL.Managers
{

    public class AdminManager:IAdminService
    {

        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IBlogService blogService;
        private readonly ICategoryService categoryService;

        public AdminManager(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IBlogService blogService, ICategoryService categoryService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.blogService = blogService;
            this.categoryService = categoryService;
        }


        public async Task<bool> AddRole(string roleName)
        {
            var result =  await roleManager.CreateAsync(new() { Name = roleName });

            return result.Succeeded;
        }
        public async Task<List<AppRole>> GetAllRole()
        {

            return   await roleManager.Roles.ToListAsync(); 
        }
        public async Task RoleAddToUser(string userId,string roleName )
        {
            var user = await userManager.FindByIdAsync(userId);

             var result = await userManager.IsInRoleAsync(user, roleName);

            if (!result)
            {
                await userManager.AddToRoleAsync(user, roleName);
            }

        }
        public async Task<bool> RemoveRolFromUser(string userId, string roleName)
        {
            var user = await userManager.FindByIdAsync(userId);

            var result = await userManager.RemoveFromRoleAsync(user, roleName);

            return result.Succeeded;
        }

        public async Task BaOrUnBanUser(string id, bool ban)
        {
            var user =  await userManager.FindByIdAsync(id);
            user.isBanned = ban;
            await userManager.UpdateAsync(user);
             await userManager.UpdateSecurityStampAsync(user); 
        }

        public async Task BlogAdd(CreateBlogDto dto)
        {
            //validation
            //
            blogService.Add(dto);
           
        }

        public async Task Category(CategoryAddDto dto )
        {
            //validation 
            categoryService.Add(dto);
        }

    }
}
