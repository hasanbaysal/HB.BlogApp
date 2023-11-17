using HB.BlogApp.BL.Managers;
using HB.BlogApp.BL.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.BL.Extentions
{
    public static class DLDepedencies
    {

        public static void   AddBLDepecenies(this IServiceCollection services)
        {


            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            #region Custom Service Aadd

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IEmailService, MailManager>();
            services.AddScoped<IAccountService, AccountManager>();

            #endregion


        }
    }
}
