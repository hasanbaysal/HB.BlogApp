using HB.BlogApp.BL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Web;

namespace HB.BlogApp.Web.Controllers
{
    public class AccountController : Controller
    {

        private IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public async Task<IActionResult> ConfirmEmail(string userId,string token)
        {



            

            var ıd =  HttpUtility.UrlDecode(userId);
            var myToken = HttpUtility.UrlDecode(token);

           var result =   await accountService.EmailActivation(myToken, ıd);
            return View();
        }

        public async Task<IActionResult> ForgetPassword()
        {

          var result =  await accountService.ForgotPassword("hasan.baysall@gmail.com");

            return View();
        }

        public async Task<IActionResult> ResetPassword(string userId,string token )
        {
            //adam şifre yenlime linkine tıklayınca geleceği yer


            var ıd = HttpUtility.UrlDecode(userId);
            var myToken = HttpUtility.UrlDecode(token);

            var result = await accountService.VerfyPasswordResetInformation(ıd, myToken);


            if (result)
            {
                TempData["ıd"] = ıd;
                TempData["myToken"] = myToken;
                return RedirectToAction(nameof(PassEdit));
            }

            return Redirect("/home/index");

          
        }


        public async Task<IActionResult> PassEdit()
        {
            var ıd = TempData["ıd"].ToString();
            var token = TempData["myToken"].ToString();

            if (ıd != null && token!= null)
            {
                var yeni_şifre = "12321Aasdasd.x!!1232";
              var result =  await   accountService.ResetPassword(yeni_şifre,ıd,token);

            }


            return Redirect("/");  
        }
    }
}
