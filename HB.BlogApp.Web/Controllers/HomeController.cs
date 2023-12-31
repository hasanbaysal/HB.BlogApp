﻿using HB.BlogApp.BL.Services;
using HB.BlogApp.Dto;
using HB.BlogApp.Dto.AppUserDtos;
using HB.BlogApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography;

namespace HB.BlogApp.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICategoryService _categoryService;
        private readonly IEmailService _emailService;
        private readonly IAccountService _accountService;
        public HomeController(ICategoryService categoryService, IEmailService emailService, IAccountService accountService)
        {
            _categoryService = categoryService;
            _emailService = emailService;
            _accountService = accountService;
        }

        public async Task<IActionResult> Index()
        {

            //var result = await _accountService.Regiser(new UserCreateDto()
            //{

            //    Email = "hasan.baysall@gmail.com",
            //    UserName = "hasan123hasan",
            //    Password = "a23uasdascCASD:Ç':!",
            //    Name = "hasan",
            //    SurName = "baysal",


            //});




            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryAddDto dto)
        {



            _categoryService.Add(dto);
            return RedirectToAction("Index");
        }




        public async Task<IActionResult> Test()
        {


            //    Email = "hasan.baysall@gmail.com",
            //    UserName = "hasan123hasan",
            //    Password = "a23uasdascCASD:Ç':!",
            //    Name = "hasan",
            //    SurName = "baysal",


            UserLoginDto dto = new();


            dto.Email = "hasan.baysall@gmail.com";
            dto.Password = "a23uasdascCASD:Ç':!";
            dto.ısRememberMe = false;
            dto.loginIP = HttpContext.Connection.RemoteIpAddress!.ToString() ?? " ";

           var loginResult =  await  _accountService.SignInAsync(dto);


            loginResult.ForEach(x => Console.WriteLine(x));
            return View();    
        }


    }
}
