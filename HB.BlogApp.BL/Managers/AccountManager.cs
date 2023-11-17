using AutoMapper;
using HB.BlogApp.BL.Services;
using HB.BlogApp.Dto;
using HB.BlogApp.Dto.AppUserDtos;
using HB.BlogApp.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Collections.Specialized.BitVector32;

namespace HB.BlogApp.BL.Managers
{
    public class AccountManager : IAccountService
    {

        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper _mapper;
        private readonly IEmailService _mailService;

        public AccountManager(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IMapper mapper, IEmailService mailService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            _mapper = mapper;
            _mailService = mailService;
        }

        public async Task<List<string>>  Regiser(UserCreateDto dto)
        {
            //void => Task
         
            var user = _mapper.Map<AppUser>(dto);


         var result =   await  userManager.CreateAsync(user, dto.Password);


            if (result.Succeeded)
            {
                //aktivasyon maili gönder

                //<a href ="link">Hesap Aktivasyon Buraya Tıklayınız </a>
               

                var registredUser =  await userManager.FindByEmailAsync(dto.Email);

                var token = await userManager.GenerateEmailConfirmationTokenAsync(registredUser);
                var userID = registredUser.Id;

                var url = EmailComfirmLinkGenerator(token,userID);
                var html = GenerateAccountActivationEmail(url);


                _mailService.SendMail(user.Email, "Email Confirm",html);

                return new List<string>();
            }


           var errorList =  result.Errors.Select(x => 
            
            x.Description
            ).ToList();

            return errorList;
        }
        public async Task<bool> EmailActivation(string token, string userId)
        {

            //user 1 token 123 +



             var user = await userManager.FindByIdAsync(userId); 

            var result =  await userManager.ConfirmEmailAsync(user, token);

            if(result.Succeeded) return true;

            if(user.EmailConfirmed) return false;




            //tekrardan email göndermem gerek

            var newToken = await userManager.GenerateEmailConfirmationTokenAsync(user);
            var link = EmailComfirmLinkGenerator(newToken, user.Id);
            var html = GenerateAccountActivationEmail(link);
            _mailService.SendMail(user.Email, "Account Activation", html);



            return false;

          
        }

        public async Task<List<string>> SignInAsync(UserLoginDto  dto)
        {

            List<string> errors = new List<string>();   

            var user =  await userManager.FindByEmailAsync(dto.Email);

            if (user == null) { 
                
                errors.Add(" kullanıcı adı yada şifre hatalı");
                return errors;
            }



            var result =  await signInManager.PasswordSignInAsync(user, dto.Password, dto.ısRememberMe, true);

            if (result.Succeeded)
            {
                user.LastLogin = dto.loginIP;
                await userManager.UpdateAsync(user);
                return errors;
            }
            //error'un içi boş hata yoktur adam giriş  yapsın

           

            if (result.IsLockedOut)
            {
                errors.Add("hesap kitlendi bekleyiniz");
                return errors;
            }

            if (result.IsNotAllowed)
            {
                errors.Add("e postanızı onaylamadınzı");
            }
            if (user != null && !result.Succeeded)
            {
                errors.Add("kullanıcı adı yada şifren hatalı");
            }



            return errors;

        }

        public async Task<string> ForgotPassword(string email)
        {

            var user = await userManager.FindByEmailAsync(email);
            if (user == null) { return " böyle biri sistemde kayıtlı değil"; } 

            //link => ıd ve token 

            var resetToken =  await userManager.GeneratePasswordResetTokenAsync(user);

            var link = ResetPasswordLinkGenerator(resetToken, user.Id);
            var mailBody = GenerateResetPasswordEmail(link);


            _mailService.SendMail(user.Email, "Şifre Yenlime", mailBody);

            return "işlem başarılı.....";
        }

        /// <summary>
        /// url'den alınan token ve id bu methoda vermeden decode etmelisin çok önemli!!!
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<bool> VerfyPasswordResetInformation(string id, string token)
        {

            //id veya token string.empty olamaz hata!!


            var user =  await userManager.FindByIdAsync(id);
            if (user == null) { return false; }


            IdentityOptions options = new IdentityOptions();
            var result = await userManager.VerifyUserTokenAsync(user, options.Tokens.PasswordResetTokenProvider, UserManager<AppUser>.ResetPasswordTokenPurpose, token);

            
            return result;
        }
        
        //şifre yenileme methodu => yeni şifre / ıd / token

        // 
        public async Task<bool> ResetPassword(string newPassword, string id, string token)
        {

            var user = await userManager.FindByIdAsync(id);

             var result=  await userManager.ResetPasswordAsync(user, token, newPassword);

            if (result.Succeeded)
            {
                
                await userManager.UpdateSecurityStampAsync(user);
            }
            return result.Succeeded;
        }



        //bir kullanıcı kendi bilgilerini güncellemek isteyebilir
        //kullanıcı şifre güncelleme                         => method
        //kullanıcı temel güncelleme  => ad, soyad, telefon,  => method 1




        private string EmailComfirmLinkGenerator(string token, string UserId)
        {
            //base path www.hasan.com  yada localhost:9090 vb
            var uriBuilder = new UriBuilder("https://localhost:7185"); 
            //path => controler ve action   a/b yada a/b/c/d.....
            uriBuilder.Path = $"/Account/ConfirmEmail";
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["userId"] = HttpUtility.UrlEncode(UserId);
            queryString["token"] = HttpUtility.UrlEncode(token);
            uriBuilder.Query = queryString.ToString();
            var data =  uriBuilder.ToString();

            return data; 
            
        }

        private string ResetPasswordLinkGenerator(string token, string UserId)
        {
            //base path www.hasan.com  yada localhost:9090 vb
            var uriBuilder = new UriBuilder("https://localhost:7185");
            //path => controler ve action   a/b yada a/b/c/d.....
            uriBuilder.Path = $"/Account/ResetPassword";
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["userId"] = HttpUtility.UrlEncode(UserId);
            queryString["token"] = HttpUtility.UrlEncode(token);
            uriBuilder.Query = queryString.ToString();
            var data = uriBuilder.ToString();

            return data;

        }

        private string GenerateAccountActivationEmail(string url)
        {

            var html = $@"<html><head></head>
                    
                        <body>

                                    <h2>HOŞGELDİN</h2>
                            <a href = {url}> Hesap Aktivasyon Buraya Tıklayınız </a>
                        </body>
    
    
    
                       </html>";

            return html;
        }

        private string GenerateResetPasswordEmail(string url)
        {

            var html = $@"<html><head></head>
                    
                        <body>

                                   
                            <a href = {url}> şifre yenilemek için buraya yıkla</a>
                        </body>
    
    
    
                       </html>";

            return html;
        }
    }



}
