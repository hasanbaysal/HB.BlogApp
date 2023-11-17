using HB.BlogApp.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.DAL.IdentityConfiguration
{
    public class IdentityCustomUserValidator : IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            //1salak
            var errors = new List<IdentityError>();    
            if (user.UserName.Contains("Salak"))
            {

                errors.Add(new IdentityError() { Code = "", Description = "kulllanıcı adı salak kelimesin içeremez!" });
              
            
            }

            if (char.IsDigit(user.UserName[0]))
            {
                errors.Add(new IdentityError() { Code = "", Description = "kulllanıcı adının ilk karakteri sayıyal bir değer olmaz" });
           

            }

            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

            return Task.FromResult(IdentityResult.Success);

        }
    }

}
