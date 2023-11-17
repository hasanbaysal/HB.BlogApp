using HB.BlogApp.DAL.Abstracts;
using HB.BlogApp.DAL.Contexts;
using HB.BlogApp.DAL.IdentityConfiguration;
using HB.BlogApp.DAL.UnitOfWork;
using HB.BlogApp.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.DAL.Extentions
{
    public  static class DALDependencies
    {
        public static void AddDALDependencies(this IServiceCollection services,string connectionStrin)
        {
            //dbcontext kayıt
            services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(connectionStrin);

            });
         

            #region Identity Container Configuration
            services.AddIdentity<AppUser, AppRole>(option =>
            {
                option.User.AllowedUserNameCharacters =
              "abcçdefgğhiıjklmnoöprsştuüvyz" +
              "ABCÇDEFGĞHİIJKLMNOÖPRSŞTUÜVYZ" +
              "QWX" + "wqx" + "1234567890";

                option.User.RequireUniqueEmail = true;
                option.SignIn.RequireConfirmedEmail = true;//ileri true
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                option.Lockout.MaxFailedAccessAttempts = 6;


                option.Password.RequiredLength = 8;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireDigit = true;


            }).AddUserValidator<IdentityCustomUserValidator>()
        .AddPasswordValidator<CustomPasswordValidator>()
        .AddDefaultTokenProviders()
        .AddEntityFrameworkStores<AppDbContext>();


            services.Configure<SecurityStampValidatorOptions>(option =>
            {
                option.ValidationInterval = TimeSpan.FromMinutes(100);
            });



            services.Configure<DataProtectionTokenProviderOptions>(option =>
            {
                option.TokenLifespan = TimeSpan.FromHours(5);
            });

            #endregion

            #region Uow and repos

            services.AddScoped<IUow, Uow>();
             
            #endregion
        }
    }
}
