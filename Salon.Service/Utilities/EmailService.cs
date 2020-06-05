using Salon.Service.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Salon.Service.Utilities
{
    public class EmailService : IEmailService
    {
        public void Send(MailMessage mailMessage)
        {
            //SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
            //client.UseDefaultCredentials = false;
            //client.EnableSsl = true;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.Credentials = new NetworkCredential("signaturenailsfreehold@gmail.com", "lkjhgfdsalkjhgfdsa");
            //MailMessage message = new MailMessage();
            //mailMessage.From = new MailAddress("signaturenailsfreehold@gmail.com");
            //mailMessage.To.Add("mikhailtalapila@yahoo.com");
            //mailMessage.Body = "Test message here";
            //mailMessage.Subject = "Subject test";
            //client.Send(mailMessage);
        }
    }
}
