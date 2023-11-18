using HB.BlogApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.BL.Services
{
    public interface IAdminService
    {

        //admin blog ekleyebilir => blog servise ihtiyacı
        //admin kategori ekleyebilir => kategor

        public Task BaOrUnBanUser(string id, bool ban);

        public Task<bool> RemoveRolFromUser(string userId, string roleName);
        public Task RoleAddToUser(string userId, string roleName);
        public Task<List<AppRole>> GetAllRole();
        public Task<bool> AddRole(string roleName);

       

    }
}
