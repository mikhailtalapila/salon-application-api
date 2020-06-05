using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salon.Service.Utilities.Interfaces;

namespace Salon.API.Controllers.api.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstanceManagementController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public InstanceManagementController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [Route("sendconfirmation")]
        public IActionResult Get()
        {
            try

            {
                MailMessage mailMessage = new MailMessage();
                _emailService.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw;
            }
            
            return Ok();
        }
    }
}