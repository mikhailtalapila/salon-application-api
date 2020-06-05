using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Salon.Service.Utilities.Interfaces
{
    public interface IEmailService
    {
        void Send(MailMessage mailMessage);
    }
}
