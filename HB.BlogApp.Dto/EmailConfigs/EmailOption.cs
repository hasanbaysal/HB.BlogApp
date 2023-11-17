using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.Dto.EmailConfigs
{
    public class EmailOption
    {
        public EmailOption ServiceEmailOption { get; set; }
        //public EmailOption SupportEmailOption { get; set; }
        public string Host { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }

    }
}
