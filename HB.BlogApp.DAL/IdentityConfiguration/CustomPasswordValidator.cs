using HB.BlogApp.Entities.Entities;
using Microsoft.AspNetCore.Identity;

namespace HB.BlogApp.DAL.IdentityConfiguration
{
    public class CustomPasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string? password)
        {
            //123456aA
            //Aa123456

            var errors = new List<IdentityError>();
            if (password!.ToLower().Contains(user.UserName!))
            {
                errors.Add(new() { Code = "2", Description = "şifre kullanıcı adı içeremez" });
            }
            if (password!.ToLower().Contains("12345"))
            {

                errors.Add(new() { Code = "Password", Description = "şifre çok basit" });
            }

            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }

}
