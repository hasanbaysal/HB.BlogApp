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


        /// <summary>
        /// url'den alınan token ve id bu methoda vermeden decode etmelisin çok önemli!!!
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<bool> VerfyPasswordResetInformation(string id, string token);
        /// <summary>
        /// id ve token decode edilmiş şekilde bu method verilmesi gerek!!!
        /// </summary>
        /// <param name="newPassword"></param>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<bool> ResetPassword(string newPassword, string id, string token);
        public Task<string> ForgotPassword(string email);
    }

}
