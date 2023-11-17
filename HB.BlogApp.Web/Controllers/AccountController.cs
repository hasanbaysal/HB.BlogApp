using HB.BlogApp.BL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
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
    }
}
