using DTO;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using System.Net.Mail;

namespace BL
{
    public class ContactBL : IContactBL
    {
        public async Task<string> sendEmail(ContactFormDto form)
        {
            return "ok";
        }
    }
}
