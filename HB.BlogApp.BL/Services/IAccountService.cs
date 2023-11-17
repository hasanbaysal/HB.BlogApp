using HB.BlogApp.Dto;
using HB.BlogApp.Dto.AppUserDtos;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.BL.Services
{
    //
    public interface IAccountService
    {

        public Task<List<string>> Regiser(UserCreateDto dto);

        public Task<bool> EmailActivation(string token, string userId);

        public Task<List<string>> SignInAsync(UserLoginDto dto);



    }

}
