using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.BL.Services
{
    public interface IEmailService
    {
        //gaws ctuh shrt ejsp
        //mail gönderme işlemi
        void SendMail(string reciverMailAddress,string subject,string mailBody);
    }
}
