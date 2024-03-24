using EmailSender.Domain.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Application.Services.EmailService
{
    public interface IEmailService
    {
        public Task SendEmailAsync(EmailModel emailModel);
    }
}
