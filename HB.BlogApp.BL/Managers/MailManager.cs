using HB.BlogApp.BL.Services;
using HB.BlogApp.Dto.EmailConfigs;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HB.BlogApp.BL.Managers
{
    public class MailManager : IEmailService
    {
        private readonly EmailOption _option;

        public MailManager(IOptions<EmailOption> option)
        {
            _option = option.Value;
        }

        public void SendMail(string reciverMailAddress,string subject,string mailBody)
        {




            try
            {

                var smtpClient = new SmtpClient();

                //smtp configleri
                //8080
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = smtpClient.DeliveryMethod;
                smtpClient.UseDefaultCredentials = false;



                smtpClient.Host = _option.ServiceEmailOption.Host;
                smtpClient.Port = _option.ServiceEmailOption.Port;
                smtpClient.Credentials = new NetworkCredential(_option.ServiceEmailOption.Email, _option.ServiceEmailOption.Password);


                var mailMessage = new MailMessage();

                mailMessage.From = new MailAddress(_option.ServiceEmailOption.Email);



                mailMessage.To.Add(reciverMailAddress);
                mailMessage.Subject = subject;
                mailMessage.Body = mailBody;
                mailMessage.IsBodyHtml = true;

                smtpClient.Send(mailMessage);
                Console.WriteLine("başarılı");
            }
            catch (Exception e)
            {


                Console.WriteLine("hata");
            }
            finally
            {
                Console.WriteLine("mail işlemi tamamlandı");
            }

        }




    }
}
